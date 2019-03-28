package halley.entity;

import javax.persistence.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

@Entity
@Table(name = "comments", schema = "s225116")
public class Comment {
    private Integer id;
    private Integer articleId;
    private Integer authorId;
    private String authorName;
    private String date;
    private String text;

    public Comment() {
        DateFormat df = new SimpleDateFormat("dd.MM.yyyy HH:mm:ss:SSSS");
        Date today = Calendar.getInstance().getTime();
        date = df.format(today);
    }

    public Comment(Integer articleId, Integer authorId, String authorName, String text) {
        this();
        this.articleId = articleId;
        this.authorId = authorId;
        this.authorName = authorName;
        this.text = text;
    }

    @Id
    @Column(name = "id", nullable = false, columnDefinition = "serial")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getId() { return id; }
    public void setId(Integer id) { this.id = id; }

    @Basic
    @Column(name = "article_id", nullable = false)
    public Integer getArticleId() { return articleId; }
    public void setArticleId(Integer articleId) { this.articleId = articleId; }

    @Basic
    @Column(name = "author_id", nullable = false)
    public Integer getAuthorId() { return authorId; }
    public void setAuthorId(Integer authorId) { this.authorId = authorId; }

    @Basic
    @Column(name = "author_name", nullable = false)
    public String getAuthorName() { return authorName; }
    public void setAuthorName(String authorName) { this.authorName = authorName; }

    @Basic
    @Column(name = "date", nullable = false)
    public String getDate() { return date; }
    public void setDate(String date) { this.date = date; }

    @Basic
    @Column(name = "text", nullable = false)
    public String getText() { return text; }
    public void setText(String text) { this.text = text; }
}
