using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Combat : MonoBehaviour
{
    public static bool Fight = false;
    
	public static List<List<int>> BattleCourses = new List<List<int>>();
	public static List<int> BattleCounters = new List<int>();
	public static List<int> RandomNumbers1 = new List<int>();
	public static List<int> RandomNumbers2 = new List<int>();
	public static List<bool> AttackersFirstStrikes = new List<bool>();
    public static List<bool> DefendersFirstStrikes = new List<bool>();
	public static List<int> AttackersLastStrikeTypes = new List<int>();
	public static List<int> DefendersLastStrikeTypes = new List<int>();
	public static List<int> AttackersFirstTypeStrikesRepetitions = new List<int>();
    public static List<int> DefendersFirstTypeStrikesRepetitions = new List<int>();

	public static List<GameObject> Attackers = new List<GameObject>();
	public static List<GameObject> Defenders = new List<GameObject>();
	public static List<Transform> AttackersTransforms = new List<Transform>();
    public static List<Transform> DefendersTransforms = new List<Transform>();
	public static List<Animator> AttackersAnimators = new List<Animator>();
	public static List<Animator> DefendersAnimators = new List<Animator>();
	public static List<GameObject> AttackersBloodSpraysObjects = new List<GameObject>();
	public static List<GameObject> DefendersBloodSpraysObjects = new List<GameObject>();
	public static List<ParticleSystem> AttackersBloodSpraysParticleSystems = new List<ParticleSystem>();
	public static List<ParticleSystem> DefendersBloodSpraysParticleSystems = new List<ParticleSystem>();
	public static List<GameObject> AttackersBloodPoolsObjects = new List<GameObject>();
	public static List<GameObject> DefendersBloodPoolsObjects = new List<GameObject>();
	public static List<ParticleSystem> AttackersBloodPoolsParticleSystems = new List<ParticleSystem>();
    public static List<ParticleSystem> DefendersBloodPoolsParticleSystems = new List<ParticleSystem>();
	public static List<GameObject> AttackersHandSwordsObjects = new List<GameObject>();
	public static List<GameObject> DefendersHandSwordsObjects = new List<GameObject>();
	public static List<MeshRenderer> AttackersHandSwordsMeshRenderers = new List<MeshRenderer>();
	public static List<MeshRenderer> DefendersHandSwordsMeshRenderers = new List<MeshRenderer>();
	public static List<GameObject> AttackersScabbardSwordsObjects = new List<GameObject>();
	public static List<GameObject> DefendersScabbardSwordsObjects = new List<GameObject>();
	public static List<MeshRenderer> AttackersScabbardSwordsMeshRenderers = new List<MeshRenderer>();
	public static List<MeshRenderer> DefendersScabbardSwordsMeshRenderers = new List<MeshRenderer>();

	IEnumerator FightCoroutine(int BattleIterator)
    {
        for (int Counter = 1; Counter <= BattleCourses[BattleIterator].Count; Counter++)
        {
            if (AttackersAnimators[BattleIterator] != null && DefendersAnimators[BattleIterator] != null)
            {
                yield return new WaitUntil(() => (AttackersAnimators[BattleIterator] == null || DefendersAnimators[BattleIterator] == null || (AttackersAnimators[BattleIterator].GetCurrentAnimatorStateInfo(0).IsName("ARCH_sword_combat_mode") && DefendersAnimators[BattleIterator].GetCurrentAnimatorStateInfo(0).IsName("ARCH_sword_combat_mode") && MoveUnit.RotateToDefault == false)));

				if (BattleCourses[BattleIterator][BattleCounters[BattleIterator]] >= 1 && BattleCourses[BattleIterator][BattleCounters[BattleIterator]] <= 3)
				{
					if (AttackersLastStrikeTypes[BattleIterator] == 0)
					{
						RandomNumbers1[BattleIterator] = Random.GetRandomNumber(1, 3);
					}
					if (AttackersLastStrikeTypes[BattleIterator] == 1 && !(AttackersFirstTypeStrikesRepetitions[BattleIterator] == 2 | AttackersFirstStrikes[BattleIterator]))
					{
						RandomNumbers1[BattleIterator] = Random.GetRandomNumber(1, 2);
					}
					if (AttackersLastStrikeTypes[BattleIterator] == 1 && (AttackersFirstTypeStrikesRepetitions[BattleIterator] == 2 | AttackersFirstStrikes[BattleIterator]))
					{
						RandomNumbers1[BattleIterator] = 3;
						AttackersFirstTypeStrikesRepetitions[BattleIterator] = 0;
					}
					if (AttackersLastStrikeTypes[BattleIterator] == 2)
					{
						RandomNumbers1[BattleIterator] = Random.GetRandomNumber(1, 2);
						if (AttackersFirstStrikes[BattleIterator])
						{
							AttackersFirstStrikes[BattleIterator] = false;
						}
					}               
					if (RandomNumbers1[BattleIterator] == 1)
					{
						AttackersAnimators[BattleIterator].SetTrigger("Thrust");
						AttackersLastStrikeTypes[BattleIterator] = 1;
						AttackersFirstTypeStrikesRepetitions[BattleIterator]++;
					}
					if (RandomNumbers1[BattleIterator] == 2)
					{
						AttackersAnimators[BattleIterator].SetTrigger("Swing_Right");
						AttackersLastStrikeTypes[BattleIterator] = 1;
						AttackersFirstTypeStrikesRepetitions[BattleIterator]++;
					}
					if (RandomNumbers1[BattleIterator] == 3)
					{
						AttackersAnimators[BattleIterator].SetTrigger("Swing_Left");
						AttackersLastStrikeTypes[BattleIterator] = 2;
					}
					if (BattleCourses[BattleIterator][BattleCounters[BattleIterator]] == 1)
					{
						AttackersAnimators[BattleIterator].SetTrigger("Return_To_Melee_Mode");
						yield return new WaitForSeconds(0.4f);
						DefendersAnimators[BattleIterator].SetTrigger("Hit");
						DefendersAnimators[BattleIterator].SetTrigger("Return_To_Melee_Mode");
						DefendersBloodSpraysParticleSystems[BattleIterator].Play();
					}
					if (BattleCourses[BattleIterator][BattleCounters[BattleIterator]] == 2)
					{
						AttackersAnimators[BattleIterator].SetTrigger("Return_To_Melee_Mode");
						DefendersAnimators[BattleIterator].SetTrigger("Dodge");
						DefendersAnimators[BattleIterator].SetTrigger("Return_To_Melee_Mode");
					}
					if (BattleCourses[BattleIterator][BattleCounters[BattleIterator]] == 3)
					{
						AttackersAnimators[BattleIterator].SetTrigger("Return_To_Melee_Mode");
						yield return new WaitForSeconds(0.4f);
						DefendersAnimators[BattleIterator].SetTrigger("Die");
						DefendersBloodPoolsParticleSystems[BattleIterator].Play();
						DefendersBloodSpraysParticleSystems[BattleIterator].Play();
						Battlefield.Tiles[UnitInterface.TargetPosition[BattleIterator].X, UnitInterface.TargetPosition[BattleIterator].Y] = null;
						Destroy(Defenders[BattleIterator], 10);
					}
				}
				if (BattleCourses[BattleIterator][BattleCounters[BattleIterator]] >= 4 && BattleCourses[BattleIterator][BattleCounters[BattleIterator]] <= 6)
				{
					if (DefendersLastStrikeTypes[BattleIterator] == 0)
					{
						RandomNumbers1[BattleIterator] = Random.GetRandomNumber(1, 3);
					}
					if (DefendersLastStrikeTypes[BattleIterator] == 1 && !(DefendersFirstTypeStrikesRepetitions[BattleIterator] == 2 | DefendersFirstStrikes[BattleIterator]))
					{
						RandomNumbers1[BattleIterator] = Random.GetRandomNumber(1, 2);
					}
					if (DefendersLastStrikeTypes[BattleIterator] == 1 && (DefendersFirstTypeStrikesRepetitions[BattleIterator] == 2 | DefendersFirstStrikes[BattleIterator]))
					{
						RandomNumbers1[BattleIterator] = 3;
						DefendersFirstTypeStrikesRepetitions[BattleIterator] = 0;
					}
					if (DefendersLastStrikeTypes[BattleIterator] == 2)
					{
						RandomNumbers1[BattleIterator] = Random.GetRandomNumber(1, 2);
						if (DefendersFirstStrikes[BattleIterator])
						{
							DefendersFirstStrikes[BattleIterator] = false;
						}
					}               
					if (RandomNumbers1[BattleIterator] == 1)
					{
						DefendersAnimators[BattleIterator].SetTrigger("Thrust");
						DefendersLastStrikeTypes[BattleIterator] = 1;
						DefendersFirstTypeStrikesRepetitions[BattleIterator]++;
					}
					if (RandomNumbers1[BattleIterator] == 2)
					{
						DefendersAnimators[BattleIterator].SetTrigger("Swing_Right");
						DefendersLastStrikeTypes[BattleIterator] = 1;
						DefendersFirstTypeStrikesRepetitions[BattleIterator]++;
					}
					if (RandomNumbers1[BattleIterator] == 3)
					{
						DefendersAnimators[BattleIterator].SetTrigger("Swing_Left");
						DefendersLastStrikeTypes[BattleIterator] = 2;
					}
					if (BattleCourses[BattleIterator][BattleCounters[BattleIterator]] == 4)
					{
						DefendersAnimators[BattleIterator].SetTrigger("Return_To_Melee_Mode");
						yield return new WaitForSeconds(0.4f);
						AttackersAnimators[BattleIterator].SetTrigger("Hit");
						AttackersAnimators[BattleIterator].SetTrigger("Return_To_Melee_Mode");
						AttackersBloodSpraysParticleSystems[BattleIterator].Play();
					}
					if (BattleCourses[BattleIterator][BattleCounters[BattleIterator]] == 5)
					{
						DefendersAnimators[BattleIterator].SetTrigger("Return_To_Melee_Mode");
						AttackersAnimators[BattleIterator].SetTrigger("Dodge");
						AttackersAnimators[BattleIterator].SetTrigger("Return_To_Melee_Mode");
					}
					if (BattleCourses[BattleIterator][BattleCounters[BattleIterator]] == 6)
					{
						DefendersAnimators[BattleIterator].SetTrigger("Return_To_Melee_Mode");
						yield return new WaitForSeconds(0.4f);
						AttackersAnimators[BattleIterator].SetTrigger("Die");
						AttackersBloodPoolsParticleSystems[BattleIterator].Play();
						AttackersBloodSpraysParticleSystems[BattleIterator].Play();
						Battlefield.Tiles[UnitInterface.SelectedUnitPosition[BattleIterator].X, UnitInterface.SelectedUnitPosition[BattleIterator].Y] = null;
						Destroy(Attackers[BattleIterator], 10);
					}
				}
                
                RandomNumbers2[BattleIterator] = Random.GetRandomNumber(50, 75);
				yield return new WaitForSeconds(Convert.ToSingle(Convert.ToSingle(RandomNumbers2[BattleIterator]) / 100));
                BattleCounters[BattleIterator]++;
            }
        }

		yield return new WaitUntil(() => (AttackersAnimators[BattleIterator] == null || DefendersAnimators[BattleIterator] == null || (AttackersAnimators[BattleIterator].GetCurrentAnimatorStateInfo(0).IsName("ARCH_sword_combat_mode") || DefendersAnimators[BattleIterator].GetCurrentAnimatorStateInfo(0).IsName("ARCH_sword_combat_mode"))));
		if (BattleCourses[BattleIterator][BattleCourses[BattleIterator].Count - 1] == 3)
        {
            if (Battlefield.Tiles[UnitInterface.SelectedUnitPosition[BattleIterator].X, UnitInterface.SelectedUnitPosition[BattleIterator].Y].Owner == 1)
            {
                if (!((AttackersTransforms[BattleIterator].rotation.eulerAngles.y > 0 && AttackersTransforms[BattleIterator].rotation.eulerAngles.y < 10) || (AttackersTransforms[BattleIterator].rotation.eulerAngles.y > 350)))
                {
                    MoveUnit.Survivors[BattleIterator] = "Attacker";
                    MoveUnit.Mode = "Strike";
                    AttackersAnimators[BattleIterator].SetTrigger("Turn_Right");
                    MoveUnit.RotateToDefault = true;
                }
            }
            if (Battlefield.Tiles[UnitInterface.SelectedUnitPosition[BattleIterator].X, UnitInterface.SelectedUnitPosition[BattleIterator].Y].Owner == 2)
            {
                if (!(AttackersTransforms[BattleIterator].rotation.eulerAngles.y > 170 && AttackersTransforms[BattleIterator].rotation.eulerAngles.y < 190))
                {
                    MoveUnit.Mode = "Strike";
                    MoveUnit.Survivors[BattleIterator] = "Attacker";
                    AttackersAnimators[BattleIterator].SetTrigger("Turn_Right");
                    MoveUnit.RotateToDefault = true;
                }
            }
        }
        if (BattleCourses[BattleIterator][BattleCounters[BattleIterator] - 1] == 6)
        {
            if (Battlefield.Tiles[UnitInterface.TargetPosition[BattleIterator].X, UnitInterface.TargetPosition[BattleIterator].Y].Owner == 1)
            {
                if (!((DefendersTransforms[BattleIterator].rotation.eulerAngles.y > 0 && DefendersTransforms[BattleIterator].rotation.eulerAngles.y < 10) || (DefendersTransforms[BattleIterator].rotation.eulerAngles.y > 350)))
                {
					MoveUnit.Survivors.Add("");
					MoveUnit.SurvivorsOwners.Add(0);
					MoveUnit.SurvivorsTransforms.Add(MoveUnit.SoldiersTransforms[0]);
                    MoveUnit.Survivors[BattleIterator] = "Defender";
                    DefendersAnimators[BattleIterator].SetTrigger("Turn_Right");
                    MoveUnit.Mode = "Strike";
                    MoveUnit.RotateToDefault = true;
                }
            }
            if (Battlefield.Tiles[UnitInterface.TargetPosition[BattleIterator].X, UnitInterface.TargetPosition[BattleIterator].Y].Owner == 2)
            {
                if (!(DefendersTransforms[BattleIterator].rotation.eulerAngles.y > 170 && DefendersTransforms[BattleIterator].rotation.eulerAngles.y < 190))
                {
					MoveUnit.Survivors.Add("");
					MoveUnit.SurvivorsOwners.Add(0);
					MoveUnit.SurvivorsTransforms.Add(MoveUnit.SoldiersTransforms[0]);
                    MoveUnit.Survivors[BattleIterator] = "Defender";
                    MoveUnit.Mode = "Strike";
                    AttackersAnimators[BattleIterator].SetTrigger("Turn_Right");
                    MoveUnit.RotateToDefault = true;
                }
            }
        }
    }
       
    void Start()
    {
		BattleCourses.Add(new List<int>());      
		BattleCounters.Add(0);
		RandomNumbers1.Add(0);
		RandomNumbers2.Add(0);
		AttackersFirstStrikes.Add(false);
        DefendersFirstStrikes.Add(false);
		AttackersLastStrikeTypes.Add(0);
		DefendersLastStrikeTypes.Add(0);
		AttackersFirstTypeStrikesRepetitions.Add(0);
        DefendersFirstTypeStrikesRepetitions.Add(0);
      
		Attackers.Add(new GameObject());
        Defenders.Add(new GameObject());
		AttackersTransforms.Add(Attackers[0].GetComponent<Transform>());
		DefendersTransforms.Add(Defenders[0].GetComponent<Transform>());
		AttackersAnimators.Add(Attackers[0].GetComponent<Animator>());
		DefendersAnimators.Add(Attackers[0].GetComponent<Animator>());
		AttackersBloodSpraysObjects.Add(new GameObject());
		DefendersBloodSpraysObjects.Add(new GameObject());
		AttackersBloodSpraysParticleSystems.Add(new ParticleSystem());
		DefendersBloodSpraysParticleSystems.Add(new ParticleSystem());
		AttackersBloodPoolsObjects.Add(new GameObject());
        DefendersBloodPoolsObjects.Add(new GameObject());
		AttackersBloodPoolsParticleSystems.Add(new ParticleSystem());
        DefendersBloodPoolsParticleSystems.Add(new ParticleSystem());
		AttackersHandSwordsObjects.Add(new GameObject());
		DefendersHandSwordsObjects.Add(new GameObject());
		AttackersHandSwordsMeshRenderers.Add(new MeshRenderer());
		DefendersHandSwordsMeshRenderers.Add(new MeshRenderer());
		AttackersScabbardSwordsObjects.Add(new GameObject());
		DefendersScabbardSwordsObjects.Add(new GameObject());
		AttackersScabbardSwordsMeshRenderers.Add(new MeshRenderer());
		DefendersScabbardSwordsMeshRenderers.Add(new MeshRenderer());
    }
    void Update()
    {
        if (Fight)
        {
            Fight = false;

			for (int Counter = 1; Counter <= UnitInterface.MatchesCounter; Counter++)
            {
				if (UnitInterface.TargetPosition[Counter].X != -1 && UnitInterface.TargetPosition[Counter].Y != -1) 
				{
					BattleCounters.Add(0);
					RandomNumbers1.Add(0);
					RandomNumbers2.Add(0);
					AttackersFirstStrikes.Add(true);
					DefendersFirstStrikes.Add(true);
					AttackersLastStrikeTypes.Add(0);
					DefendersLastStrikeTypes.Add(0);
					AttackersFirstTypeStrikesRepetitions.Add(0);
					DefendersFirstTypeStrikesRepetitions.Add(0);
					Attackers.Add(GameObject.Find("Soldier" + UnitInterface.SelectedUnitPosition[Counter].X + UnitInterface.SelectedUnitPosition[Counter].Y));
					Defenders.Add(GameObject.Find("Soldier" + UnitInterface.TargetPosition[Counter].X + UnitInterface.TargetPosition[Counter].Y));
					AttackersTransforms.Add(Attackers[Counter].GetComponent<Transform>());
					DefendersTransforms.Add(Defenders[Counter].GetComponent<Transform>());
					AttackersAnimators.Add(Attackers[Counter].GetComponent<Animator>());
					DefendersAnimators.Add(Defenders[Counter].GetComponent<Animator>());
					AttackersBloodSpraysObjects.Add(Attackers[Counter].transform.Find("BloodSpray").gameObject);
					DefendersBloodSpraysObjects.Add(Defenders[Counter].transform.Find("BloodSpray").gameObject);
					AttackersBloodSpraysParticleSystems.Add(AttackersBloodSpraysObjects[Counter].GetComponent<ParticleSystem>());
					DefendersBloodSpraysParticleSystems.Add(DefendersBloodSpraysObjects[Counter].GetComponent<ParticleSystem>());
					AttackersBloodPoolsObjects.Add(Attackers[Counter].transform.Find("BloodStream").gameObject);
					DefendersBloodPoolsObjects.Add(Defenders[Counter].transform.Find("BloodStream").gameObject);
					AttackersBloodPoolsParticleSystems.Add(AttackersBloodPoolsObjects[Counter].GetComponent<ParticleSystem>());
					DefendersBloodPoolsParticleSystems.Add(DefendersBloodPoolsObjects[Counter].GetComponent<ParticleSystem>());
					if (Battlefield.Tiles[UnitInterface.SelectedUnitPosition[Counter].X, UnitInterface.SelectedUnitPosition[Counter].Y] is Archer)
                    {
                        AttackersHandSwordsObjects.Add(Attackers[Counter].transform.Find("Bip01").gameObject.transform.Find("Bip01 Pelvis").gameObject.transform.Find("Bip01 Spine").gameObject.transform.Find("Bip01 Spine1").gameObject.transform.Find("Bip01 Spine2").gameObject.transform.Find("Bip01 R Clavicle").gameObject.transform.Find("Bip01 R UpperArm").gameObject.transform.Find("Bip01 R Forearm").gameObject.transform.Find("Bip01 R Hand").gameObject.transform.Find("Bip01 Rhand_Weapon").gameObject.transform.Find("sword01").gameObject);
                        AttackersHandSwordsMeshRenderers.Add(AttackersHandSwordsObjects[Counter].GetComponent<MeshRenderer>());                  
                        AttackersScabbardSwordsObjects.Add(Attackers[Counter].transform.Find("Bip01").gameObject.transform.Find("Bip01 Pelvis").gameObject.transform.Find("Bip01 right_Wmount").gameObject.transform.Find("sword").gameObject);                  
                        AttackersScabbardSwordsMeshRenderers.Add(AttackersScabbardSwordsObjects[Counter].GetComponent<MeshRenderer>());
                        AttackersHandSwordsMeshRenderers[Counter].enabled = true;
                        AttackersScabbardSwordsMeshRenderers[Counter].enabled = false;
                    } 
					if (Battlefield.Tiles[UnitInterface.TargetPosition[Counter].X, UnitInterface.TargetPosition[Counter].Y] is Archer)
					{
						DefendersHandSwordsObjects.Add(Defenders[Counter].transform.Find("Bip01").gameObject.transform.Find("Bip01 Pelvis").gameObject.transform.Find("Bip01 Spine").gameObject.transform.Find("Bip01 Spine1").gameObject.transform.Find("Bip01 Spine2").gameObject.transform.Find("Bip01 R Clavicle").gameObject.transform.Find("Bip01 R UpperArm").gameObject.transform.Find("Bip01 R Forearm").gameObject.transform.Find("Bip01 R Hand").gameObject.transform.Find("Bip01 Rhand_Weapon").gameObject.transform.Find("sword01").gameObject);
						DefendersHandSwordsMeshRenderers.Add(DefendersHandSwordsObjects[Counter].GetComponent<MeshRenderer>());
						DefendersScabbardSwordsObjects.Add(Defenders[Counter].transform.Find("Bip01").gameObject.transform.Find("Bip01 Pelvis").gameObject.transform.Find("Bip01 right_Wmount").gameObject.transform.Find("sword").gameObject);
						DefendersScabbardSwordsMeshRenderers.Add(DefendersScabbardSwordsObjects[Counter].GetComponent<MeshRenderer>());
						DefendersHandSwordsMeshRenderers[Counter].enabled = true;
						DefendersScabbardSwordsMeshRenderers[Counter].enabled = false;
					}
					if (Battlefield.Tiles[UnitInterface.SelectedUnitPosition[Counter].X, UnitInterface.SelectedUnitPosition[Counter].Y] is Infantryman)
                    {
						AttackersHandSwordsObjects.Add(new GameObject());
                        AttackersHandSwordsMeshRenderers.Add(AttackersHandSwordsObjects[Counter].GetComponent<MeshRenderer>());
						AttackersScabbardSwordsObjects.Add(new GameObject());
                        AttackersScabbardSwordsMeshRenderers.Add(AttackersScabbardSwordsObjects[Counter].GetComponent<MeshRenderer>());
                    }
					if (Battlefield.Tiles[UnitInterface.TargetPosition[Counter].X, UnitInterface.TargetPosition[Counter].Y] is Infantryman)
                    {
						DefendersHandSwordsObjects.Add(new GameObject());
                        DefendersHandSwordsMeshRenderers.Add(DefendersHandSwordsObjects[Counter].GetComponent<MeshRenderer>());
						DefendersScabbardSwordsObjects.Add(new GameObject());
                        DefendersScabbardSwordsMeshRenderers.Add(DefendersScabbardSwordsObjects[Counter].GetComponent<MeshRenderer>());
                    }
					AttackersAnimators[Counter].SetTrigger("Melee_Mode");
					DefendersAnimators[Counter].SetTrigger("Melee_Mode");
				}
				else
				{
					BattleCounters.Add(0);
                    RandomNumbers1.Add(0);
                    RandomNumbers2.Add(0);
                    AttackersFirstStrikes.Add(true);
					DefendersFirstStrikes.Add(true);
                    AttackersLastStrikeTypes.Add(0);
                    DefendersLastStrikeTypes.Add(0);
                    AttackersFirstTypeStrikesRepetitions.Add(0);
                    DefendersFirstTypeStrikesRepetitions.Add(0);
					Attackers.Add(GameObject.Find("Soldier" + UnitInterface.SelectedUnitPosition[Counter].X + UnitInterface.SelectedUnitPosition[Counter].Y));
					Defenders.Add(new GameObject());
                    AttackersTransforms.Add(Attackers[Counter].GetComponent<Transform>());
                    DefendersTransforms.Add(Defenders[Counter].GetComponent<Transform>());
                    AttackersAnimators.Add(Attackers[Counter].GetComponent<Animator>());
                    DefendersAnimators.Add(Defenders[Counter].GetComponent<Animator>());
					AttackersBloodSpraysObjects.Add(Attackers[Counter].transform.Find("BloodSpray").gameObject);
					DefendersBloodSpraysObjects.Add(new GameObject());
                    AttackersBloodSpraysParticleSystems.Add(AttackersBloodSpraysObjects[Counter].GetComponent<ParticleSystem>());
                    DefendersBloodSpraysParticleSystems.Add(DefendersBloodSpraysObjects[Counter].GetComponent<ParticleSystem>());
					AttackersBloodPoolsObjects.Add(Attackers[Counter].transform.Find("BloodStream").gameObject);
					DefendersBloodPoolsObjects.Add(new GameObject());
                    AttackersBloodPoolsParticleSystems.Add(AttackersBloodPoolsObjects[Counter].GetComponent<ParticleSystem>());
                    DefendersBloodPoolsParticleSystems.Add(DefendersBloodPoolsObjects[Counter].GetComponent<ParticleSystem>());
  					if (Battlefield.Tiles[UnitInterface.SelectedUnitPosition[Counter].X, UnitInterface.SelectedUnitPosition[Counter].Y] is Archer)
                    {
                        AttackersHandSwordsObjects.Add(Attackers[Counter].transform.Find("Bip01").gameObject.transform.Find("Bip01 Pelvis").gameObject.transform.Find("Bip01 Spine").gameObject.transform.Find("Bip01 Spine1").gameObject.transform.Find("Bip01 Spine2").gameObject.transform.Find("Bip01 R Clavicle").gameObject.transform.Find("Bip01 R UpperArm").gameObject.transform.Find("Bip01 R Forearm").gameObject.transform.Find("Bip01 R Hand").gameObject.transform.Find("Bip01 Rhand_Weapon").gameObject.transform.Find("sword01").gameObject);
                        AttackersHandSwordsMeshRenderers.Add(AttackersHandSwordsObjects[Counter].GetComponent<MeshRenderer>());
                        AttackersScabbardSwordsObjects.Add(Attackers[Counter].transform.Find("Bip01").gameObject.transform.Find("Bip01 Pelvis").gameObject.transform.Find("Bip01 right_Wmount").gameObject.transform.Find("sword").gameObject);
                        AttackersScabbardSwordsMeshRenderers.Add(AttackersScabbardSwordsObjects[Counter].GetComponent<MeshRenderer>());
                        AttackersHandSwordsMeshRenderers[Counter].enabled = true;
                        AttackersScabbardSwordsMeshRenderers[Counter].enabled = false;
                    }
                    if (Battlefield.Tiles[UnitInterface.SelectedUnitPosition[Counter].X, UnitInterface.SelectedUnitPosition[Counter].Y] is Infantryman)
                    {
                        AttackersHandSwordsObjects.Add(new GameObject());
                        AttackersHandSwordsMeshRenderers.Add(AttackersHandSwordsObjects[Counter].GetComponent<MeshRenderer>());
                        AttackersScabbardSwordsObjects.Add(new GameObject());
                        AttackersScabbardSwordsMeshRenderers.Add(AttackersScabbardSwordsObjects[Counter].GetComponent<MeshRenderer>());
                    }
					DefendersHandSwordsObjects.Add(new GameObject());
					DefendersHandSwordsMeshRenderers.Add(DefendersHandSwordsObjects[Counter].GetComponent<MeshRenderer>());
					DefendersScabbardSwordsObjects.Add(new GameObject());
                    DefendersScabbardSwordsMeshRenderers.Add(DefendersScabbardSwordsObjects[Counter].GetComponent<MeshRenderer>());               
                    
					AttackersAnimators[Counter].SetTrigger("Melee_Mode");
				}
            }
			SelectUnit.ClickLock3 = false;

			for (int Counter = 1; Counter <= UnitInterface.MatchesCounter; Counter++)
            {            
				if (UnitInterface.TargetPosition[Counter].X != -1 && UnitInterface.TargetPosition[Counter].Y != -1)
				{
					StartCoroutine(FightCoroutine(Counter));
				}
            }
        }
    }
}