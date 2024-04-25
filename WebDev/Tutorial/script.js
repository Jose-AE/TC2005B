const imageContainer = document.getElementById("images");
const selector = document.getElementById("selector");
const button = document.getElementById("mainButton");

async function getImgUrl() {
  const response = await fetch(
    `https://api.thecatapi.com/v1/images/search?limit=1
    `
  );
  const images = await response.json();
  return images;
}

async function loadImages() {
  imgCount = parseInt(selector.value);
  const imageUrls = []; // Wait for the URL to be fetched

  for (let x = 0; x < imgCount; x++) {
    const img = await getImgUrl(imgCount);
    imageUrls.push(img[0]);
  }

  console.log(imageUrls);

  htmlToAdd = "";

  for (let i = 0; i < imageUrls.length; i++) {
    htmlToAdd += getHtmlBody(imageUrls[i].url);
  }

  imageContainer.innerHTML = htmlToAdd;
}

button.onclick = loadImages;

function getHtmlBody(imgUrl) {
  return `<div class="col-lg-4 mb-5">
  <div class="card h-100 shadow border-0">
    <img id="img2" class="card-img-top" src="${imgUrl}" alt="..." />
    <div class="card-body p-4">
      <div class="badge bg-primary bg-gradient rounded-pill mb-2">
        Media
      </div>
      <a
        class="text-decoration-none link-dark stretched-link"
        href="#!"
      ></a>
    </div>
  </div>
</div>`;
}
