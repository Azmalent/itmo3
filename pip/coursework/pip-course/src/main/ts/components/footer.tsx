import * as React from "react";

export class Footer extends React.Component<{}, {}> {

    public render(): JSX.Element {
        return (
            <footer className="sticky hidden-sm hidden-md">
                <span>
                    <strong>Давлетшин Рушан, Съестов Дмитрий © 2018&nbsp;</strong>
                    <small>
                        Иконка от&nbsp;
                        <a href="https://www.freepik.com/free-vector/space-icon-collection_1000139.htm">
                            Zirconicusso
                        </a>
                        <span>&nbsp;|&nbsp;</span>
                        Фон от&nbsp;
                        <a href="https://www.freepik.com/free-vector/star-background-with-planets_1594486.htm">
                            freepik
                        </a>
                        <span>&nbsp;|&nbsp;</span>
                        Иконка Земли от&nbsp;
                        <a href="https://openclipart.org/detail/211386/globe-icon-facing-europe-and-africa">
                            Sev
                        </a>
                    </small>
                    <a href="http://www.wtfpl.net/">
                        <img src="http://www.wtfpl.net/wp-content/uploads/2012/12/wtfpl-badge-1.png"
                             width="88" height="31" alt="WTFPL"/>
                    </a>
                </span>
            </footer>
        );
    }
}

export default Footer;
