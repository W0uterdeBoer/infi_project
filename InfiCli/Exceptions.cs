class NoCameraNumberException : Exception
{
    public NoCameraNumberException()
        : base("Camera does not have a number, did you search 'ERROR'? ")
    {

    }
}