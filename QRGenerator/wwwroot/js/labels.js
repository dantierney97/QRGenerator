
window.generateBarcodeImage = (barcodeValue) => {
    try {

        // Validate the input to ensure it's a string
        if (!barcodeValue || typeof barcodeValue !== "string") {
            throw new Error("Expected a string for the barcode value.");
        }

        // Create a canvas element for barcode generation
        const canvas = document.createElement("canvas");
        JsBarcode(canvas, barcodeValue, {
            format: "CODE128",
            width: 2,
            height: 50,
            displayValue: true,
        });

        // Return the barcode image as a Data URL
        return canvas.toDataURL("image/png");
    } catch (error) {
        console.error("Error generating barcode:", error.message);
        return "";
    }
};