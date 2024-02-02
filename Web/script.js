async function generateKey() {
    try {
        const response = await fetch('http://encryptionapi-env.eba-mp8gwi3q.eu-north-1.elasticbeanstalk.com/key');
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

    try {
        const response = await fetch('http://encryptionapi-env.eba-mp8gwi3q.eu-north-1.elasticbeanstalk.com/encryption/encrypt', {
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

    try {
        const response = await fetch('http://encryptionapi-env.eba-mp8gwi3q.eu-north-1.elasticbeanstalk.com/encryption/decrypt', {
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