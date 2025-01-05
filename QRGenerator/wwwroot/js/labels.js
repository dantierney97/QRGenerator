
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
}

window.adjustFontSize = () => {
    // Get all elements with the class 'productName' and 'productPrice'
    const elements = document.querySelectorAll('.productName, .productPrice');

    elements.forEach(element => {
        const parent = element.parentElement;
        const parentWidth = parent.offsetWidth;
        const parentHeight = parent.offsetHeight;

        let fontSize = 10; // Starting font size
        const maxFontSize = 100; // Arbitrary max font size for safety

        // Temporarily set font size to measure
        element.style.fontSize = `${fontSize}px`;

        // Keep increasing the font size until the text overflows
        while (
            fontSize < maxFontSize &&
            element.scrollWidth <= parentWidth &&
            element.scrollHeight <= parentHeight
            ) {
            fontSize++;
            element.style.fontSize = `${fontSize}px`;
        }

        // Reduce font size slightly to fit within container
        element.style.fontSize = `${fontSize - 10}px`;
    });
};