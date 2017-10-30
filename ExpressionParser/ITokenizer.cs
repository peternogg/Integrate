namespace ExpressionParser
{
    public interface ITokenizer
    {
        Token CurrentToken { get; }
        string Expression { get; }
        bool HasTokens { get; }

        Token ConsumeToken();
        void MoveNext();
    }
}