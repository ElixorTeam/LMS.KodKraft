(function () {
    document.addEventListener('keydown', (e) => {
        if (e.key.toLowerCase() !== 'd') return;

        const target = e.target;

        if (
            target instanceof HTMLInputElement ||
            target instanceof HTMLTextAreaElement ||
            (target instanceof HTMLElement && target.isContentEditable)
        )
            return;

        e.preventDefault();
        window.toggleTheme();
    });
})();
