import * as React from "react";
import Carousel from "react-alice-carousel";
import {uniqueId} from "lodash";
import {ArticlePreview} from "./article/articlePreview";
import {IArticleProps} from "./article/article";
import {parseJson} from "../utils";

export class Home extends React.Component<{}, {}> {
    public render(): JSX.Element {
        const latestArticles = parseJson("/rest/articles?p=0").map((props: IArticleProps) =>
            <div key={uniqueId("carouselItem_")} onDragStart={e => e.preventDefault()}>
                <ArticlePreview {...props}/>
            </div>
        );

        return (
            <Carousel mouseDragEnabled>
                {latestArticles}
            </Carousel>
        );
    }
}

export default Home;
