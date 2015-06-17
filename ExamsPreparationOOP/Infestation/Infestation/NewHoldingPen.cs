using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infestation.Supplements;

namespace Infestation
{
    public class NewHoldingPen : HoldingPen
    {
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            Unit unit = GetUnit(commandWords[2]);
            switch (commandWords[1])
            {
                case "Weapon":
                    unit.AddSupplement(new Weapon());
                    break;
                case "PowerCatalyst":
                    unit.AddSupplement(new PowerCatalyst());
                    break;
                case "AggressionCatalyst":
                    unit.AddSupplement(new AggressionCatalyst());
                    break;
                case "HealthCatalyst":
                    unit.AddSupplement(new HealthCatalyst());
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
            }
            base.ExecuteInsertUnitCommand(commandWords);
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    var target = GetUnit(interaction.TargetUnit);
                    target.AddSupplement(new InfestationSpores());
                    break;
            }
            base.ProcessSingleInteraction(interaction);
        }
    }
}