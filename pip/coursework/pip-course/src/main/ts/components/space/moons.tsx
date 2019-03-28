import * as React from "react";
import {uniqueId} from "lodash";
import {addPropsToChildren} from "../../utils";

export interface IMoonsProps {
    around: string;
}

export class Moons extends React.Component<IMoonsProps, {}> {
    public render(): JSX.Element[] {
        const {around, children} = this.props;
        return addPropsToChildren(children, {key: uniqueId("planet_"), sunId: around});
    }
}

export default Moons;
