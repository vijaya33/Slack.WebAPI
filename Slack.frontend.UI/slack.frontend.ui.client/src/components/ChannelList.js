import React from 'react';

function ChannelList({ channels, current, onSelect }) {
    return (
        <div className="channel-list">
            <h3>Channels</h3>
            <ul>
                {channels.map(channel => (
                    <li
                        key={channel.id}
                        className={current && current.id === channel.id ? 'selected' : ''}
                        onClick={() => onSelect(channel)}
                        style={{ cursor: 'pointer', fontWeight: current && current.id === channel.id ? 'bold' : 'normal' }}
                    >
                        #{channel.name}
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default ChannelList;
