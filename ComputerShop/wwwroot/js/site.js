// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.addEventListener("load", () => {
  const footer = document.getElementById("footer");
  const date = new Date();
  const year = date.getFullYear();

  footer.innerHTML = `&copy; ${year} - Computer Shop`
})

//let screenSizePrioritySlider = document.getElementById("screenSizePriority");
//let screenSizePriorityValueLabel = document.getElementById("screenSizePriorityValueLabel");

let corePrioritySlider = document.getElementById("corePriority");
let corePriorityValueLabel = document.getElementById("corePriorityValueLabel");

let clockSpeedPrioritySlider = document.getElementById("clockSpeedPriority");
let clockSpeedPriorityValueLabel = document.getElementById("clockSpeedPriorityValueLabel");

let ramPrioritySlider = document.getElementById("ramPriority");
let ramPriorityValueLabel = document.getElementById("ramPriorityValueLabel");

let storagePrioritySlider = document.getElementById("storagePriority");
let storagePriorityValueLabel = document.getElementById("storagePriorityValueLabel");

let pricePrioritySlider = document.getElementById("pricePriority");
let pricePriorityValueLabel = document.getElementById("pricePriorityValueLabel");

//screenSizePrioritySlider.addEventListener("change", () => {
//  screenSizePriorityValueLabel.innerHTML = screenSizePrioritySlider.value + "%";
//});

function setSliderValueSumLabelContentAndColor() {
  let sliderValuesSum = corePrioritySlider.valueAsNumber + clockSpeedPrioritySlider.valueAsNumber
    + ramPrioritySlider.valueAsNumber + storagePrioritySlider.valueAsNumber + pricePrioritySlider.valueAsNumber;

  let prioritySumLabel = document.getElementById("prioritySum");
  prioritySumLabel.innerHTML = sliderValuesSum + "%";

  let submitButton = document.getElementById("submitButton");

  if (sliderValuesSum == 100) {
    prioritySumLabel.style.color = "green";
    submitButton.disabled = false;
  } else {
    prioritySumLabel.style.color = "red";
    submitButton.disabled = true;
  }
}

corePrioritySlider.addEventListener("change", () => {
  corePriorityValueLabel.innerHTML = corePrioritySlider.value + "%";
  setSliderValueSumLabelContentAndColor();
});

clockSpeedPrioritySlider.addEventListener("change", () => {
  clockSpeedPriorityValueLabel.innerHTML = clockSpeedPrioritySlider.value + "%";
  setSliderValueSumLabelContentAndColor();
});

ramPrioritySlider.addEventListener("change", () => {
  ramPriorityValueLabel.innerHTML = ramPrioritySlider.value + "%";
  setSliderValueSumLabelContentAndColor();
});

storagePrioritySlider.addEventListener("change", () => {
  storagePriorityValueLabel.innerHTML = storagePrioritySlider.value + "%";
  setSliderValueSumLabelContentAndColor();
});

pricePrioritySlider.addEventListener("change", () => {
  pricePriorityValueLabel.innerHTML = pricePrioritySlider.value + "%";
  setSliderValueSumLabelContentAndColor();
});

let coresCheckbox = document.getElementById("coresCheckbox");
let coresInput = document.getElementById("coresInput");

let clockSpeedCheckbox = document.getElementById("clockSpeedCheckbox");
let clockSpeedInput = document.getElementById("clockSpeedInput");

let ramCheckbox = document.getElementById("ramCheckbox");
let ramInput = document.getElementById("ramInput");

let storageCheckbox = document.getElementById("storageCheckbox");
let storageInput = document.getElementById("storageInput");

let priceCheckbox = document.getElementById("priceCheckbox");
let priceInput = document.getElementById("priceInput");

coresCheckbox.addEventListener("change", () => {
  coresInput.disabled = coresCheckbox.checked;
  coresInput.value = "";
});

clockSpeedCheckbox.addEventListener("change", () => {
  clockSpeedInput.disabled = clockSpeedCheckbox.checked;
  clockSpeedInput.value = "";
});

ramCheckbox.addEventListener("change", () => {
  ramInput.disabled = ramCheckbox.checked;
  ramInput.value = "";
});

storageCheckbox.addEventListener("change", () => {
  storageInput.disabled = storageCheckbox.checked;
  storageInput.value = "";
});

priceCheckbox.addEventListener("change", () => {
  priceInput.disabled = priceCheckbox.checked;
  priceInput.value = "";
});