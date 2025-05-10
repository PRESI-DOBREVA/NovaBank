window.addEventListener('load', () => {
    document.querySelectorAll('.dropdown').forEach(dropdown => {
        const button = dropdown.querySelector('.dropdown-button');
        const menu = dropdown.querySelector('.dropdown-content');

        if (button && menu) {
            menu.style.width = `${button.offsetWidth}px`;
        }
    });
});

