using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private DiamondScore _diamondScore;

    public override void InstallBindings()
    {
        BindDiamondScore();
    }

    private void BindDiamondScore()
    {
        Container.Bind<DiamondScore>().FromInstance(_diamondScore).AsSingle();
    }
}