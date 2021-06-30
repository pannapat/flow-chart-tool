
public class GraphEdge<T>
{
    T value;

    public GraphEdge(T value)
    {
        this.value = value;
    }

    public T Value
    {
        get { return value; }
    }
}