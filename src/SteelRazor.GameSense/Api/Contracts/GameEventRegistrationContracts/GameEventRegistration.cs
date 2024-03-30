﻿using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts.GameEventRegistrationContracts;

internal sealed class GameEventRegistration
{
    [JsonPropertyName("game")]
    public string Game { get; set; } = string.Empty;

    [JsonPropertyName("event")]
    public string Event { get; set; } = string.Empty;

    [JsonPropertyName("min_value")]
    public int? MinValue { get; set; }

    [JsonPropertyName("max_value")]
    public int? ManValue { get; set; }

    [JsonPropertyName("icon_id")]
    public int? IconId { get; set; }

    [JsonPropertyName("value_optional")]
    public bool? IsOptional { get; set; }
}