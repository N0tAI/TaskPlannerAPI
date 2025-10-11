namespace Thayen.WebPlanner.Data.Models;

public readonly struct IdType
{
	private readonly Guid _value;

	public IdType(Guid value)
	{
		if (value == Guid.Empty)
			throw new ArgumentException("Id cannot be empty", nameof(value));
		_value = value;
	}

	public Guid Value => _value;

	public static IdType NewId() => new IdType(Guid.NewGuid());

	public static implicit operator Guid(IdType id) => id._value;

	public static explicit operator IdType(Guid guid) => new IdType(guid);

	public override string ToString() => _value.ToString();

	public override bool Equals(object? obj) => obj is IdType other && _value.Equals(other._value);

	public override int GetHashCode() => _value.GetHashCode();

	public static bool operator ==(IdType left, IdType right) => left.Equals(right);

	public static bool operator !=(IdType left, IdType right) => !left.Equals(right);
}