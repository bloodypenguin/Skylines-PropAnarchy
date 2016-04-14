using PropAnarchy.OptionsFramework;
using UnityEngine;

namespace PropAnarchy
{
    public class ToolMonitor : MonoBehaviour
    {
        private PropAnarchyUI _ui;

        public void Update()
        {
            if (_ui == null)
            {
                _ui = gameObject.GetComponent<PropAnarchyUI>();
            }
            if (_ui == null)
            {
                return;
            }
            var toolActive = (ToolsModifierControl.GetCurrentTool<TreeTool>() != null || ToolsModifierControl.GetCurrentTool<PropTool>() != null ||
                OptionsWrapper<Options>.Options.allowAnarchyWhenPlacingBuildingsAndRoads && (ToolsModifierControl.GetCurrentTool<NetTool>() != null || ToolsModifierControl.GetCurrentTool<BuildingTool>() != null));
            if (toolActive)
            {
                _ui.Show();
            }
            else
            {
                _ui.Hide();
            }

            if (_ui.AnarchyOn && toolActive)
            {
                DetoursManager.Deploy();
                if (OptionsWrapper<Options>.Options.pauseSimulationWhenAnarchyOn)
                {
                    SimulationManager.instance.SimulationPaused = true;
                }
            }
            else
            {
                DetoursManager.Revert();
            }
        }
    }
}