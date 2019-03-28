import javax.persistence.*;

@Entity
@Table(name = "points", schema = "s225116")
public class Point
{
    private int id;
    private double x;
    private double y;
    private double r;
    private boolean hit;

    public Point() { }
    public Point(double x, double y, double r)
    {
        this.x = x;
        this.y = y;
        this.r = r;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    public int getId() { return id; }
    public void setId(int id) { this.id = id; }

    @Basic
    @Column(name = "x", nullable = false)
    public double getX() { return x; }
    public void setX(double x) { this.x = x; }

    @Basic
    @Column(name = "y", nullable = false)
    public double getY() { return y; }
    public void setY(double y) { this.y = y;}

    @Basic
    @Column(name = "r", nullable = false)
    public double getR() { return r; }
    public void setR(double r) { this.r = r; }

    @Basic
    @Column(name = "hit", nullable = false)
    public boolean isHit() { return hit; }
    public void setHit(boolean hit) { this.hit = hit; }
}
