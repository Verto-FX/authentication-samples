import base64
from cryptography.hazmat.backends import default_backend
from cryptography.hazmat.primitives import serialization, hashes
from cryptography.hazmat.primitives.asymmetric import padding

# Read the public key from file
with open('public.pem', 'rb') as key_file:
    public_key = serialization.load_pem_public_key(
        key_file.read(),
        backend=default_backend()
    )

# Set the API key
# Example of api key 130WHXWE6M2S0JVFDCPXFR8Q4HYJ6T2XBNRX6MMMYJR3H20PY0M78V3
api_key = b'<USER_API_KEY>'

# Encrypt the data
encrypted_data = public_key.encrypt(
    api_key,
    padding.OAEP(
        mgf=padding.MGF1(algorithm=hashes.SHA256()),
        algorithm=hashes.SHA256(),
        label=None
    )
)

# Convert the encrypted data to Base64
encoded_data = base64.b64encode(encrypted_data)

# Print the result
print('Encrypted Data (Base64):', encoded_data.decode('utf-8'))
