window.generateQRCode = (content, canvasId) => {
    // Ensure content is not empty
    if (!content || content.trim() === "") {
        console.error("Content is empty");
        return;
    }

    // Get the canvas element
    const canvas = document.getElementById(canvasId);
    if (!canvas) {
        console.error("Canvas element not found");
        return;
    }

    // Generate the QR code using qrcode.js
    QRCode.toCanvas(canvas, content, { width: 177, margin: 10 }, function (error) {
        if (error) {
            console.error("Error generating QR code:", error);
        }
    });
};