import * as React from "react";
import Planet from "./planet";
import Moons from "./moons";
import Earth from "../../../webapp/img/earth.svg";
import {parseJson} from "../../utils";

export class Space extends React.Component<{}, {}> {
    constructor(props: {}) {
        super(props);
    }

    componentDidMount() {
        setTimeout(location.hash = "sun", 100);
    }

    public render(): JSX.Element {
        return (
            <div id="space-background">
                <div id="stars"/>
                <Planet id="sun" name="Солнце"/>
                <Moons around="sun">
                    <Planet id="mercury" name="Меркурий"
                            orbit={{radius:0.25, period:0.24}}/>
                    <Planet id="venus" name="Венера"
                            orbit={{radius:0.5,  period: 0.615}}/>
                    <Planet id="earth" name="Земля"
                            orbit={{radius: 1,   period: 1}}/>
                    <Planet id="mars" name="Марс"
                            orbit={{radius:1.5, period:1.88}}/>
                    <Planet id="jupiter" name="Юпитер"
                            orbit={{radius:2.5,  period:11.857}}/>
                    <Planet id="saturn" name="Сатурн"
                            orbit={{radius:4.05, period: 29.4}}/>
                    <Planet id="uranus" name="Уран"
                            orbit={{radius:5.10,    period: 84.02}}/>
                    <Planet id="neptune" name="Нептун"
                            orbit={{radius:7.33, period: 164.79}}/>
                    <Planet id="pluto" name="Плутон"
                            orbit={{radius:9, period: 247.92}}/>
                </Moons>
                <Moons around="earth">
                    <Planet id="moon" name="Луна"
                            orbit={{radius: 0.1, period: 0.075}}/>
                </Moons>
                <Moons around="mars">
                    <Planet id="phobos" name="Фобос"
                            orbit={{radius: 0.1, period: 0.002}}/>
                    <Planet id="deimos" name="Деймос"
                            orbit={{radius: 0.2, period: 0.007}}/>
                </Moons>
                <Moons around="jupiter">
                    <Planet id="io" name="Ио"
                            orbit={{radius: 0.05, period: 0.005}}/>
                    <Planet id="europa" name="Европа"
                            orbit={{radius: 0.125, period: 0.01}}/>
                    <Planet id="ganymede" name="Ганимед"
                            orbit={{radius: 0.2, period: 0.02}}/>
                    <Planet id="callisto" name="Каллисто"
                            orbit={{radius: 0.375, period: 0.05}}/>
                </Moons>
            </div>
        );
    }
}

export default Space;
