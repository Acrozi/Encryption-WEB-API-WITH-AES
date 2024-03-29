async function generateKey() {
    try {
        const response = await fetch('https://d3qq1t4yottxdj.cloudfront.net/key');
        const data = await response.json();
        document.getElementById('encryptionKey').value = data.key;
    } catch (error) {
        console.error('Error generating key:', error);
        alert('Error generating key. Please check the console for details.');
    }
}

async function encryptText() {
    const inputText = document.getElementById('inputText').value;
    const encryptionKey = document.getElementById('encryptionKey').value;

    // Check if inputText or encryptionKey is empty
    if (!inputText.trim() || !encryptionKey.trim()) {
        alert('Input text or encryption key cannot be empty.');
        return;
    }

    try {
        const response = await fetch('https://d3qq1t4yottxdj.cloudfront.net/encryption/encrypt', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                plaintext: inputText,
                key: encryptionKey
            })
        });

        const data = await response.json();
        document.getElementById('encryptedText').value = data.encryptedText;
    } catch (error) {
        console.error('Error encrypting text:', error);
        alert('Error encrypting text. Please check the console for details.');
    }
}

async function decryptText() {
    const encryptedText = document.getElementById('encryptedInput').value;
    const decryptionKey = document.getElementById('decryptionKey').value;

    // Check if encryptedText or decryptionKey is empty
    if (!encryptedText.trim() || !decryptionKey.trim()) {
        alert('Encrypted text or decryption key cannot be empty.');
        return;
    }

    try {
        const response = await fetch('https://d3qq1t4yottxdj.cloudfront.net/encryption/decrypt', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                ciphertext: encryptedText,
                key: decryptionKey
            })
        });

        const data = await response.json();
        document.getElementById('decryptedText').value = data.decryptedText;
    } catch (error) {
        console.error('Error decrypting text:', error);
        alert('Error decrypting text. Please check the console for details.');
    }
}
