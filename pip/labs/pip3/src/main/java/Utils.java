public class Utils
{
    public static double distance(Point a, Point b)
    {
        return Math.sqrt(Math.pow(a.x - b.x, 2) + Math.pow(a.y - b.y, 2));
    }

    public static double triangleArea(Point a, Point b, Point c)
    {
        double ab = distance(a, b), bc = distance(b, c), ca = distance(c, a), p = (ab + bc + ca) / 2;
        return Math.sqrt(p * (p - ab) * (p - bc) * (p - ca));
    }

    public static boolean doubleEquals(double a, double b)
    {
        final double EPSILON = 1E-5;
        return Math.abs(a - b) < EPSILON;
    }
}