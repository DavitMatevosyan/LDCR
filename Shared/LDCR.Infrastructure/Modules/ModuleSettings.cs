namespace LDCR.Infrastructure.Modules;

public record ModuleSettings(
    string Name,
    bool DatabaseEnabled, 
    bool ElasticEnabled, 
    bool Enabled, 
    bool MediatrEnabled, 
    bool MetricsEnabled, 
    ModuleTesting Testing);