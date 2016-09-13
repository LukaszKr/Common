namespace ProceduralLevel.Common.Input
{
	public interface IInputValidator<InputType>
    {
		bool IsInputValid(InputType input);
	}
}
