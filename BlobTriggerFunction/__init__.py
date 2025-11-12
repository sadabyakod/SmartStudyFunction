import logging
import azure.functions as func

def main(myblob: func.InputStream):
    logging.info(f"Blob trigger function processed blob\n"
                 f"Name: {myblob.name}\n"
                 f"Blob Size: {myblob.length} bytes")
    # Here you can add logic to send a message, e.g., to a queue or notification service
    # For demonstration, we'll just log a message
    logging.info(f"A new file was uploaded: {myblob.name}")
