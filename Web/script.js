function encrypt() {
    var inputText = document.getElementById("inputText").value.trim(); // Trim whitespace

    if (!inputText) {
        alert("Please enter text to encrypt.");
        return; // Stop execution if input is null
    }

    var apiUrl = "http://encryptionapi-env.eba-mp8gwi3q.eu-north-1.elasticbeanstalk.com/key";

    // Skicka en GET-begäran till API-servern för att hämta nyckeln
    fetch(apiUrl)
    .then(response => response.json())
    .then(data => {
        var key = data.key; // Hämta nyckeln från JSON-svaret

        var encryptUrl = "http://encryptionapi-env.eba-mp8gwi3q.eu-north-1.elasticbeanstalk.com/encryption/encrypt";

        // Skicka en GET-begäran till API-servern för att kryptera texten med den hämtade nyckeln
        fetch(encryptUrl + "?key=" + key + "&plaintext=" + inputText)
        .then(response => response.json())
        .then(data => {
            // Uppdatera HTML med den krypterade texten och nyckeln från API-svaret
            document.getElementById("encryptedText").value = data.encryptedText;
            document.getElementById("encryptionKey").value = key;
            document.getElementById("encryptedLink").href = data.link;
            document.getElementById("encryptedTextDiv").style.display = "block";
        })
        .catch(error => {
            console.error('Error:', error);
        });
    })
    .catch(error => {
        console.error('Error:', error);
        alert('An error occurred while fetching the key.');
    });
}


function decrypt() {
    var inputHash = document.getElementById("inputHash").value;
    var decryptionKey = document.getElementById("decryptionKey").value.trim(); // Trim whitespace

    if (!inputHash || !decryptionKey) {
        alert("Please enter encrypted hash and decryption key.");
        return; // Stop execution if input is null
    }

    var apiUrl = "http://encryptionapi-env.eba-mp8gwi3q.eu-north-1.elasticbeanstalk.com/encryption/decrypt";

    // Skicka en GET-begäran till API-servern för att dekryptera texten
    fetch(apiUrl + "?key=" + decryptionKey + "&ciphertext=" + inputHash)
    .then(response => {
        if (!response.ok) {
            throw new Error('Invalid key or ciphertext');
        }
        return response.json();
    })
    .then(data => {
        // Uppdatera HTML med den dekrypterade texten från API-svaret
        document.getElementById("decryptedText").value = data.decryptedText;
        document.getElementById("decryptedTextDiv").style.display = "block";
    })
    .catch(error => {
        console.error('Error:', error);
        alert('Error: Invalid key or ciphertext');
    });
}
