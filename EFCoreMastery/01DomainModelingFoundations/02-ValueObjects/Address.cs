//A Value Object has no identity. If two addresses have the same street and city, they are considered equal.
// They should also be immutable.

public record Address(string Street, string City, string ZipCode);