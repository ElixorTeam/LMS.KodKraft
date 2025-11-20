const themeKey = 'color-theme'

/**
 * Switches the theme of the application based on the provided theme name.
 * @param {string} theme - The name of the theme to switch to. Possible values are 'dark', 'light', or 'system'.
 * @return {void} This function does not return a value.
 */
// @ts-ignore
window.switchTheme = (theme: string): void => {
    const root = document.documentElement
    let isDarkMode = theme === 'dark'

    if (theme === 'system') {
        localStorage.removeItem(themeKey)
        isDarkMode = window.matchMedia('(prefers-color-scheme: dark)').matches
    } else {
        localStorage.setItem(themeKey, theme)
    }

    root.classList.toggle('dark', isDarkMode)
}

/**
 * Initializes the theme of the application based on the stored color theme in localStorage or the user's system preferences.
 * If the color theme is 'dark' or the system prefers a dark color scheme, the 'dark' class is added to the root element.
 * If not, the 'dark' class is removed from the root element.
 * @returns {void} This function does not return a value.
 */
// @ts-ignore
window.initializeTheme = (): void => {
    if (
        localStorage.getItem(themeKey) === 'dark' ||
        (!(themeKey in localStorage) && window.matchMedia('(prefers-color-scheme: dark)').matches)
    )
        document.documentElement.classList.add('dark')
    else document.documentElement.classList.remove('dark')
}

/**
 * Toggles the theme between dark and light.
 * If the current theme is dark, switches to light.
 */
// @ts-ignore
window.toggleTheme = (): void => {
    let currentTheme = localStorage.getItem(themeKey) ?? 'system';

    let activeTheme: 'dark' | 'light';
    if (currentTheme === 'system') {
        activeTheme = window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
    } else {
        activeTheme = currentTheme as 'dark' | 'light';
    }

    const newTheme = activeTheme === 'dark' ? 'light' : 'dark';

    // @ts-ignore
    window.switchTheme(newTheme);
}