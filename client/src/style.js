export const setContentMargin = () => {
  const navbarHeight = document.querySelector('.navbar').offsetHeight;
  const contentElement = document.querySelector('.content');
  contentElement.style.marginTop = `${navbarHeight}px`;
}