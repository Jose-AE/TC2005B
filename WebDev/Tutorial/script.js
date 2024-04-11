const apiUrl = "https://api.thecatapi.com/v1/images/search?limit=3";

const images = [
  document.getElementById("img1"),
  document.getElementById("img2"),
  document.getElementById("img3"),
];

async function getImgsUrl() {
  const response = await fetch(apiUrl);
  const images = await response.json();
  return images;
}

async function setImageSrc() {
  const imageUrls = await getImgsUrl(); // Wait for the URL to be fetched

  for (let i = 0; i < images.length; i++) {
    images[i].src = imageUrls[i].url;
  }
}

setImageSrc(); // Call the function to set the image src
