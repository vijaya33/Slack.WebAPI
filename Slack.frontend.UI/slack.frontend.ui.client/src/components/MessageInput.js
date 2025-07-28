import React, { useState } from 'react';

function MessageInput({ onSend }) {
    const [text, setText] = useState('');
    return (
        <form
            onSubmit={e => {
                e.preventDefault();
                if (!text.trim()) return;
                onSend(text);
                setText('');
            }}
            style={{ marginTop: 8 }}
        >
            <input
                type="text"
                placeholder="Type a message..."
                value={text}
                onChange={e => setText(e.target.value)}
                style={{ width: '80%' }}
            />
            <button type="submit">Send</button>
        </form>
    );
}

export default MessageInput;
