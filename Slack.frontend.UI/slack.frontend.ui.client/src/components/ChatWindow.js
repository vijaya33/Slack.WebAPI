import React, { useEffect, useRef } from 'react';

function ChatWindow({ channel, messages, user, onSend, signalRConnection }) {
    const messageEndRef = useRef(null);

    useEffect(() => {
        messageEndRef.current?.scrollIntoView({ behavior: 'smooth' });
    }, [messages]);

    useEffect(() => {
        if (!signalRConnection) return;

        const handler = (userName, messageText) => {
            onSend({
                userId: user.id,
                user: user.displayName,
                text: messageText,
                channelId: channel.id,
                timestamp: new Date().toISOString()
            }, true); // true = received from SignalR

        };
        signalRConnection.on("ReceiveMessage", handler);
        return () => {
            signalRConnection.off("ReceiveMessage", handler);
        };
    }, [signalRConnection, onSend, user, channel]);

    return (
        <div className="chat-window">
            <h4>#{channel.name}</h4>
            <div className="messages">
                {messages.map((m, idx) => (
                    <div key={idx} className={m.userId === user.id ? 'message own' : 'message'}>
                        <span className="user">{m.user}: </span>
                        <span className="text">{m.text}</span>
                        <span className="timestamp">{new Date(m.timestamp).toLocaleTimeString()}</span>
                    </div>
                ))}
                <div ref={messageEndRef} />
            </div>
        </div>
    );
}

export default ChatWindow;
