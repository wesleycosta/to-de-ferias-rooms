﻿namespace ToDeFerias.Core.Notifier;
public sealed class ValidationMessages
{
    public static string NotInformed(string field) =>
        $"Field {field} is not found";

    public static string IdentifierIsInvalid() =>
        "Field id is invalid";
    
    public static string GreaterThan(string field, int number = 0) =>
        $"Field {field} should be greater than {number}";

    public static string NotFoundInDatabase(string field) =>
        $"Field {field} was not found in the database";

    public static string TheFieldCannotBeEmpty(string field) =>
        $"The field {field} cannot be empty";
}
