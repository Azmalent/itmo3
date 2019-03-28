import * as React from "react";
import orbit from "../../orbit";
import {uniqueId} from "lodash";
import {Link} from "react-router-dom";
import {parseJson} from "../../utils";

const MSECONDS_PER_YEAR: number = 1000 * 365.24;
const PIXELS_PER_AU: number     = 500;

export interface IPlanetProps {
    id: string;
    name: string;
    orbit?: {
        radius: number; //в а.е.
        period: number; //в земных годах
    };
    sunId?: string;
}

export interface IPlanetState {
    description?: string;
}

export class Planet extends React.Component<IPlanetProps, IPlanetState> {
    constructor(props: IPlanetProps) {
        super(props);

        const description = parseJson("/rest/articles/name?name=" + props.name, false);
        this.state = {
            description: description ? description.text : "Описание отсутствует"
        };
    }

    componentDidMount() {
        const {id, sunId} = this.props;
        if (this.props.orbit) {
            const {radius, period} = this.props.orbit;

            const centerStyle = window.getComputedStyle(document.getElementById(sunId));
            const pxRadius = radius * PIXELS_PER_AU + parseInt(centerStyle.width)/2;
            const msPeriod = period * MSECONDS_PER_YEAR;
            orbit(id, sunId, pxRadius, msPeriod);
        }
    }

    public render(): JSX.Element[] {
        const toggle = (id: string) => {
            const checkbox = document.getElementById(id) as HTMLInputElement;
            checkbox.checked = true;
        };

        const dialogId = uniqueId("dialog_");

        const {id, name} = this.props;
        const {description} = this.state;
        return ([
            <div id={id} key={uniqueId("planet_")} onClick={() => toggle(dialogId)} className="planet"/>,
            <div key={dialogId}>
                <input type="checkbox" id={dialogId} className="modal"/>
                <div>
                    <div className="card">
                        <label htmlFor={dialogId} className="modal-close"/>
                        <h3 className="section">{name}</h3>
                        <p className="section">{description}</p>
                        <Link to={"/articles/search/" + name} className="section">Связанные статьи</Link>
                    </div>
                </div>
            </div>
        ]);
    }
}

export default Planet;
