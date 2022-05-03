using Assets.Scripts.Unity;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using Main = Towers_Hit_Everything.Main;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonInfo(typeof(Main),"Towers Hit Everything", "1.0.0", "Not_Graham")]
namespace Towers_Hit_Everything
{
   
    public class Main : BloonsTD6Mod
    {
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
                var weapon = tower.GetWeapons();
                for (int i = 0; i < weapon.Count; i++)
                {
                    weapon[i].projectile.canCollisionBeBlockedByMapLos = false;
                    weapon[i].projectile.ignoreBlockers = true;
                    var damagemodel = weapon[i].projectile.GetDamageModel();
                    damagemodel.immuneBloonProperties = BloonProperties.None;
                    //damagemodel.distributeToChildren = true;
                    damagemodel.immuneBloonPropertiesOriginal = BloonProperties.None;
                }
        
            }
        }
    
    }
    
}