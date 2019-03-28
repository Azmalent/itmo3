package halley.entity;

import javax.persistence.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

@Entity
@Table(name = "articles", schema = "s225116")
public class Article
{
    private Integer id;
    private String name;
    private String date;
    private String text;

    public Article() {
        DateFormat df = new SimpleDateFormat("dd.MM.yyyy HH:mm:ss:SSSS");
        Date today = Calendar.getInstance().getTime();
        date = df.format(today);
    }

    public Article(String name, String text) {
        this();
        this.name = name;
        this.text = text;
    }

    @Id
    @Column(name = "id", nullable = false, columnDefinition = "serial")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getId() { return id; }
    public void setId(Integer id) { this.id = id; }

    @Basic
    @Column(name = "name", nullable = false, unique = true)
    public String getName() { return name; }
    public void setName(String name) { this.name = name; }

    @Basic
    @Column(name = "date", nullable = false)
    public String getDate() { return date; }
    public void setDate(String date) { this.date = date; }

    @Basic
    @Column(name = "text", nullable = false, columnDefinition = "text")
    public String getText() { return text; }
    public void setText(String text) { this.text = text; }
}