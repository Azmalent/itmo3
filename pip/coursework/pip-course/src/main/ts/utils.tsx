import * as React from "react";
import {ReactChild, ReactElement, ReactNode} from "react";

export function addProps(Component: ReactElement<any> | ReactChild, newProps: any) {
    const ValidComponent = Component as ReactElement<any>;
    return <ValidComponent.type {...ValidComponent.props} {...newProps} />;
}

export function addPropsToChildren(children: ReactNode, newProps: any): any[] {
    return React.Children.map(children, child => addProps(child, newProps));
}

export function parseBoolean(value: string): boolean {
    const lowercaseValue = value.toLowerCase();
    if (lowercaseValue == "true") {
        return true;
    } else if (lowercaseValue == "false") {
        return false;
    } else {
        return null;
    }
}

export function parseJson(url: string, doAlert: boolean = true): any {
    const xhr = new XMLHttpRequest();
    xhr.open("GET", url, false);
    xhr.send();

    if (xhr.status === 200) {
        return JSON.parse(xhr.responseText);
    }

    if (doAlert) {
        alert("Ошибка " + xhr.status + ": " + xhr.statusText);
    }
    return undefined;
}

export function buildQuery(baseUrl: string, params: {name: string, value: string}[]): string {
    const queryParams = params.filter(p => p.value).map(p => ({
            name: encodeURIComponent(p.name),
            value: encodeURIComponent(p.value)
        }));

    const query = queryParams.map(p => p.name + "=" + p.value).join("&");
    return baseUrl + (query ? "?" + query : "");
}

