// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.addEventListener("load", () => {
  const footer = document.getElementById("footer");
  const date = new Date();
  const year = date.getFullYear();

  footer.innerHTML = `&copy; ${year} - Computer Shop`
})
