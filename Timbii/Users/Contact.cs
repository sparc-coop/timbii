namespace Timbii.Users;
public class Contact(string? address1, string? address2, string? city, string? state, string? postalCode, string? country, List<Email> emails, List<Phone> phoneNumbers)
{
    public string? UserId { get; set; }
    public string? Address1 { get; set; } = address1;
    public string? Address2 { get; set; } = address2;
    public string? City { get; set; } = city;
    public string? State { get; set; } = state;
    public string? PostalCode { get; set; } = postalCode;
    public string? Country { get; set; } = country;
    public List<Email> EmailAddresses { get; set; } = emails;
    public List<Phone> PhoneNumbers { get; set; } = phoneNumbers;
    public string? StateAbbrev => GetStateByName(State ?? string.Empty);
    public string? AddressString => $"{City}, {StateAbbrev} {PostalCode}";

    public string GetStateByName(string name)
    {
        return name.ToUpper() switch
        {
            "ALABAMA" => "AL",
            "ALASKA" => "AK",
            "AMERICAN SAMOA" => "AS",
            "ARIZONA" => "AZ",
            "ARKANSAS" => "AR",
            "CALIFORNIA" => "CA",
            "COLORADO" => "CO",
            "CONNECTICUT" => "CT",
            "DELAWARE" => "DE",
            "DISTRICT OF COLUMBIA" => "DC",
            "FEDERATED STATES OF MICRONESIA" => "FM",
            "FLORIDA" => "FL",
            "GEORGIA" => "GA",
            "GUAM" => "GU",
            "HAWAII" => "HI",
            "IDAHO" => "ID",
            "ILLINOIS" => "IL",
            "INDIANA" => "IN",
            "IOWA" => "IA",
            "KANSAS" => "KS",
            "KENTUCKY" => "KY",
            "LOUISIANA" => "LA",
            "MAINE" => "ME",
            "MARSHALL ISLANDS" => "MH",
            "MARYLAND" => "MD",
            "MASSACHUSETTS" => "MA",
            "MICHIGAN" => "MI",
            "MINNESOTA" => "MN",
            "MISSISSIPPI" => "MS",
            "MISSOURI" => "MO",
            "MONTANA" => "MT",
            "NEBRASKA" => "NE",
            "NEVADA" => "NV",
            "NEW HAMPSHIRE" => "NH",
            "NEW JERSEY" => "NJ",
            "NEW MEXICO" => "NM",
            "NEW YORK" => "NY",
            "NORTH CAROLINA" => "NC",
            "NORTH DAKOTA" => "ND",
            "NORTHERN MARIANA ISLANDS" => "MP",
            "OHIO" => "OH",
            "OKLAHOMA" => "OK",
            "OREGON" => "OR",
            "PALAU" => "PW",
            "PENNSYLVANIA" => "PA",
            "PUERTO RICO" => "PR",
            "RHODE ISLAND" => "RI",
            "SOUTH CAROLINA" => "SC",
            "SOUTH DAKOTA" => "SD",
            "TENNESSEE" => "TN",
            "TEXAS" => "TX",
            "UTAH" => "UT",
            "VERMONT" => "VT",
            "VIRGIN ISLANDS" => "VI",
            "VIRGINIA" => "VA",
            "WASHINGTON" => "WA",
            "WEST VIRGINIA" => "WV",
            "WISCONSIN" => "WI",
            "WYOMING" => "WY",
            _ => throw new Exception("Not Available"),
        };
    }
}

public class Email(string? type, string? address)
{
    public string? Type { get; set; } = type;
    public string? Address { get; set; } = address;
}

public class Phone(string? type, string? number)
{
    public string? Type { get; set; } = type;
    public string? Number { get; set; } = number;
}