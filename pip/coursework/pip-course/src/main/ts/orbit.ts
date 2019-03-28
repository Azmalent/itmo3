import {random} from "lodash";

let progressTracker: {[element: string]: {current: number; max: number}} = {};

function orbit(elementId: string, centerId: string, radius: number, period: number): void {
    const element: HTMLElement = document.getElementById(elementId);
    const center: HTMLElement  = document.getElementById(centerId);

    const angleSpeed: number = radius * 2 * Math.PI / period;
    console.log(elementId + " " + angleSpeed);
    //todo: update frequency adjustment

    const max = 1000;
    progressTracker[elementId] = {
        max: max,
        current: random(0, max)
    };
    updatePosition(element, center, radius, elementId);
    setInterval(() => updatePosition(element, center, radius, elementId), period/max);
}

function updatePosition(planet: HTMLElement, sun: HTMLElement, radius: number, elementId: string) {
    const sunStyle: CSSStyleDeclaration = window.getComputedStyle(sun);
    const sunRadius: number = parseInt(sunStyle.width) / 2;
    const centerX: number   = parseInt(sunStyle.left) + sunRadius;
    const centerY: number   = parseInt(sunStyle.top) + sunRadius;

    const p = progressTracker[elementId];
    const alpha = 2 * Math.PI * p.current/p.max;
    const x = centerX + radius * Math.cos(alpha);
    const y = centerY - radius * Math.sin(alpha);

    const planetRadius = parseInt(window.getComputedStyle(planet).width) / 2;
    planet.style.left = (x - planetRadius) + "px";
    planet.style.top  = (y - planetRadius) + "px";

    if (p.current >= p.max) {
        progressTracker[elementId].current = 0;
    } else {
        progressTracker[elementId].current++;
    }
}

export default orbit;