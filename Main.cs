using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using Main = Towers_Hit_Everything.Main;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonInfo(typeof(Main), "Towers Hit Everything", "1.0.0", "Not_Graham")]

namespace Towers_Hit_Everything
{
    public class Main : BloonsTD6Mod
    {
        public override string GithubReleaseURL =>
            "https://api.github.com/repos/Not-Graham/Towers-Hit-Everything/releases";

        private static readonly ModSettingBool AllBloons = new ModSettingBool(true)
        {
            displayName = "Towers Hit All Bloon Types",
        };
        public override void OnApplicationStart() 
        {
            base.OnApplicationStart();
            LoggerInstance.Msg("Towers Hit Everything loaded");
        }

        public override void OnMainMenu()
        {
            foreach (var tower in Game.instance.model.towers)
            {
                tower.ignoreBlockers = true;
                var attackmodels = tower.GetAttackModels();
                foreach (var attack in attackmodels)
                { attack.attackThroughWalls = true; }
                var weapons = tower.GetWeapons();
                foreach (var weapon in weapons)
                {
                    weapon.projectile.canCollisionBeBlockedByMapLos = false;
                    weapon.projectile.ignoreBlockers = true;
                    if (AllBloons && (weapon.projectile.GetBehavior<DamageModel>() != null))
                    {
                        var damagemodel = weapon.projectile.GetDamageModel();
                        damagemodel.immuneBloonProperties = BloonProperties.None;
                        //damagemodel.distributeToChildren = true;
                        damagemodel.immuneBloonPropertiesOriginal = BloonProperties.None;
                    }
                }
            }
        }
    }
}