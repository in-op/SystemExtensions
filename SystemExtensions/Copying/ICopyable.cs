namespace SystemExtensions.Copying
{
    public interface ICopyable<T>
    {
        T DeepCopy();
    }
}
