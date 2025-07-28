const API_URL = 'https://localhost:5001/api'; // Update as needed

export async function fetchChannels(token) {
    const res = await fetch(`${API_URL}/channel`, {
        headers: { Authorization: `Bearer ${token}` }
    });
    return res.json();
}

export async function fetchMessages(channelId, token) {
    const res = await fetch(`${API_URL}/message/${channelId}`, {
        headers: { Authorization: `Bearer ${token}` }
    });
    return res.json();
}

export async function postMessage(message, token) {
    const res = await fetch(`${API_URL}/message`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        },
        body: JSON.stringify(message)
    });
    return res.json();
}
