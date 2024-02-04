using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatParser
{
    public partial class Form1 : Form
    {
        public bool bNoDatRaсe;
        public bool bNoDatRaсe_add;

        public bool junk1B_dual;

        string objectId = "";
        string drop_type = "";
        string drop_anim_type = "";
        string drop_radius = "";
        string drop_height = "";
        string drop_texture = "";
        string drop_mesh = "";
        string f_HumnFigh_add = "", m_HumnFigh_add = "",
                m_DarkElf_add = "", f_DarkElf_add = "",
                m_Dorf_add = "", f_Dorf_add = "",
                m_Elf_add = "", f_Elf_add = "",
                m_HumnMyst_add = "", f_HumnMyst_add = "",
                m_OrcFigh_add = "", f_OrcFigh_add = "",
                m_OrcMage_add = "", f_OrcMage_add = "";

        string icon = "";
        string weight = "";
        string material_type = "";
        string crystallizable = "";
        string body_part = "";

        string m_HumnFigh = "", f_HumnFigh = "",
                m_DarkElf = "", f_DarkElf = "",
                m_Dorf = "", f_Dorf = "",
                m_Elf = "", f_Elf = "",
                m_HumnMyst = "", f_HumnMyst = "",
                m_OrcFigh = "", f_OrcFigh = "",
                m_OrcMage = "", f_OrcMage = "";

        string item_sound = "", drop_sound = "", equip_sound = "";
        string armor_type = "";
        string crystal_type = "";
        string mp_bonus = "";

        //weapon
        string durability = "";
        string handness = "";
        string wp_mesh = "";
        string texture = "";
        string effect = "";
        string random_damage = "";
        string weapon_type = "";
        string mp_consume = "";
        string soulshot_count = "";
        string spiritshot_count = "";
        string curvature = "";
        string can_equip_hero = "";
        string Enchanted = "";
        string EnchantedMesh = ""; //Undegraund
        string EnchantedMeshOffset = ""; //Undegraund
        string EnchantedMeshScale = ""; //Undegraund
        //Npc
        string wp_mesh_NPC = "";
        string texture_name = "";
        string class_name = "";
        string property_list = "";
        string npc_speed = "";
        string attack_sound1 = "";
        string defense_sound1 = "";
        string damage_sound = "";
        string deco_effect = "";
        string attack_effect = "";

        string sound_rad = "", sound_vol = "", sound_rnd = "";
        public enum Filter
        {
            DAT_DropTex,
            DAT_DropTexWeapon,
            DAT_Race,
            DAT_icon,
            DAT_Sound,
            DAT_Race_Add,
            DAT_Wp_Mesh,
            DAT_Wp_Mesh_Tex,
            DAT_Texture_Name_Npc,
            DAT_property_list,
            DAT_DeccoEffect,
            DAT_Enchanted,
            DAT_EnchantedValue
        }

        public void ResetValues()
        {
            bNoDatRaсe = false;
            bNoDatRaсe_add = false;
            junk1B_dual = false;


         objectId = "";
         drop_type = "";
         drop_anim_type = "";
         drop_radius = "";
         drop_height = "";
         drop_texture = "";
         drop_mesh = "";
            f_HumnFigh_add = ""; m_HumnFigh_add = "";
            m_DarkElf_add = ""; f_DarkElf_add = "";
            m_Dorf_add = ""; f_Dorf_add = "";
            m_Elf_add = ""; f_Elf_add = "";
            m_HumnMyst_add = ""; f_HumnMyst_add = "";
            m_OrcFigh_add = ""; f_OrcFigh_add = "";
            m_OrcMage_add = ""; f_OrcMage_add = "";

         icon = "";
         weight = "";
         material_type = "";
         crystallizable = "";
         body_part = "";

            m_HumnFigh = ""; f_HumnFigh = "";
                m_DarkElf = ""; f_DarkElf = "";
                m_Dorf = ""; f_Dorf = "";
                m_Elf = ""; f_Elf = "";
                m_HumnMyst = ""; f_HumnMyst = "";
                m_OrcFigh = ""; f_OrcFigh = "";
                m_OrcMage = ""; f_OrcMage = "";

            item_sound = "";
            drop_sound = "";
            equip_sound = "";
         armor_type = "";
         crystal_type = "";
         mp_bonus = "";

        //weapon
         durability = "";
         handness = "";
         wp_mesh = "";
         texture = "";
         effect = "";
         random_damage = "";
         weapon_type = "";
         mp_consume = "";
         soulshot_count = "";
         spiritshot_count = "";
         curvature = "";
         can_equip_hero = "";
         Enchanted = "";
         EnchantedMesh = ""; //Undegraund
         EnchantedMeshOffset = ""; //Undegraund
         EnchantedMeshScale = ""; //Undegraund
        //Npc
         wp_mesh_NPC = "";
         texture_name = "";
         class_name = "";
         property_list = "";
         npc_speed = "";
         attack_sound1 = "";
         defense_sound1 = "";
         damage_sound = "";
         deco_effect = "";
         attack_effect = "";

            sound_rad = ""; sound_vol = ""; sound_rnd = "";
    }


        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Undegraund[26]");
            comboBox1.Items.Add("Shinemaker[447]");
            comboBox2.Items.Add("Intelude С5");

            if (comboBox1.Text == "")
                comboBox1.SelectedIndex = 0;
            if (comboBox2.Text == "")
                comboBox2.SelectedIndex = 0;
        }

        public string ParseNameToNum(string Name, int Num)
        {
            Dictionary<string, string[]> mappings = new Dictionary<string, string[]>
            {
                {"1", new string[]{
                "underwear", "0", "rear", "1", "neck", "3", "rfinger", "4", "head", "6",
                "gloves", "9", "chest", "10", "legs", "11", "feet", "12", "back", "13",
                "onepiece", "15", "alldress", "16", "hair", "17", "rhand1", "18", "hairall", "19"}},
                {"2", new string[]{ "none", "0", "d", "1", "c", "2", "b", "3", "a", "4", "s", "5", "l", "5","r", "5","r95", "5","r99","5","r110", "5","s80", "5","event", "5"}},
                {"3", new string[]{"none", "0", "light", "1", "heavy", "2", "magic", "3"}},
                {"4", new string[]{
                "oriharukon", "1", "mithril", "2", "bronze", "6", "steel", "8", "wood", "13",
                "bone", "14", "cloth", "17", "paper", "18", "leather", "19", "crystal", "23",
                "adamantaite", "47", "blood_steel", "48", "chrysolite", "49", "damascus", "50",
                "fine_steel", "51", "horn", "52", "silver", "8"}},
                {"5", new string[]{
                "underwear", "0", "rhand", "7", "lhand","8", "lrhand", "14"}},
                {"6", new string[]{
                   "0", "0","1", "1","2", "2","3", "3","4", "4","5", "5","6", "6","7", "7","8", "5", "9", "1", "10","3", "11", "5"
                   , "12", "1", "13", "3", "14", "4", "16", "4"
                   , "18", "1", "19", "1", "20", "1"}},
                {"7", new string[]{
                   "fist", "0","sword", "1","blunt", "2",
                    "dagger", "3","pole", "4","fist2", "5",
                    "bow", "6","buster", "7","dual", "8",
                    "fishingrod", "10","crossbow", "6","ancientsword", "1",
                    "twohandsword", "1","twohandstaff", "2",
                    "dualfist", "0","weapon_etc", "7",
                    "staff", "2","twohandblunt", "2","rapier", "1",
                    "dualblunt", "2","twohandcrossbow", "5","dualdagger", "8"}}
            };

            if(comboBox1.SelectedIndex == 0)
                return Name;
            
            string numString = Num.ToString();
            if (mappings.ContainsKey(numString))
            {
                string[] names = mappings[numString];
                for (int i = 0; i < names.Length; i += 2)
                    if (names[i] == Name)
                        if (i + 1 < names.Length)
                            return names[i + 1];
                        else
                            return "0";
            }
            return "0";
        }

        string Find(string Param, string FindParam)
        {
            string input = textBox0.Text;
            string[] parts = input.Split('\t');
            foreach (var part in parts)
            {
                if (part.StartsWith(FindParam))
                {
                    Param = part.Substring(FindParam.Length);
                    break;
                }
            }
            if (Param == "")
            {
                textBox1.Text += FindParam + "None\r\n";
                bNoDatRaсe = true;
            }
            return Param;
        }

        string ParseDat(string DatValue, string FindValue, Filter FilterValue)
        {
            string input = textBox0.Text;



            DatValue = Find(DatValue, FindValue);
            if (input != "")
            {             
                string input1 = DatValue;
                string pattern1 = @"\[([^\]]+)\]";

                string wordsBefore = "";
                string wordsAfter = "";
                MatchCollection matchesBefore;

                if (input1.Length == 0)
                    return DatValue;

                if (FilterValue == Filter.DAT_DropTexWeapon)
                {
                    Match match_3 = Regex.Match(input1, @"\{\[([^;\]]+?)\];\{\[([^;]+?)\]};\[None\];\[None\]\};\{\[([^;\]]+?)\];\{\[([^;]+?)\]};\[None\];\[None\]\};\{\[([^;\]]+?)\];\{\[([^;]+?)\]};\[None\];\[None\]\}\}");
                    Match match_2 = Regex.Match(input1, @"\{\[([^;\]]+?)\];\{\[([^;]+?)\]};\[None\];\[None\]\};\{\[([^;\]]+?)\];\{\[([^;]+?)\]};\[None\];\[None\]\}\}");
                    Match match_1 = Regex.Match(input1, @"\{\[([^;\]]+?)\];\{\[([^;]+?)\]};\[None\];\[None\]\}\}");
                    Match match_shild_2 = Regex.Match(input1, @"\{\[([^;\]]+?)\];\{\[([^;\]]+?)\];\[([^;\]]+?)\]};\[None];\[None\]\}\}");

                    Match match_1_Und = Regex.Match(input1, @"\=\{\[([^;\]]+?)\]\;\[([^;\]]+?)\];\[([^;\]]+?)\]");

                    if (comboBox1.SelectedIndex == 1)  //446
                    {
                        if (match_3.Groups[5].Value.Length > 0 && match_3.Groups[6].Value.Length > 0)
                            DatValue = (match_3.Groups[1].Value + "\t" + match_3.Groups[3].Value + "\t" + match_3.Groups[5].Value + "\t" + match_3.Groups[2].Value + "\t" + match_3.Groups[4].Value + "\t" + match_3.Groups[6].Value + "\t");
                        else if (match_2.Groups[3].Value.Length != 0 && match_2.Groups[4].Value.Length != 0)
                            DatValue = (match_2.Groups[1].Value + "\t" + match_2.Groups[3].Value + "\t" + "\t" + match_2.Groups[2].Value + "\t" + match_2.Groups[4].Value + "\t" + "\t");

                        else if (match_shild_2.Groups[1].Value.Length > 0 && match_shild_2.Groups[2].Value.Length > 0 && match_shild_2.Groups[3].Value.Length > 0)
                            DatValue = (match_shild_2.Groups[1].Value + "\t" + "\t" + "\t" + match_shild_2.Groups[2].Value + "\t" + match_shild_2.Groups[3].Value + "\t" + "\t");
                        else
                            DatValue = (match_1.Groups[1].Value + "\t" + "\t" + "\t" + match_1.Groups[2].Value + "\t" + "\t" + "\t");

                    }
                    else 
                    {
                        string pattern = @"\[([^\]]*?)\]";  
                        string result = "";
                        MatchCollection matches = Regex.Matches(input1, pattern);
                        int maxCount = Math.Min(matches.Count, 3);                   
              
                        for (int i = 0; i < maxCount; i++)
                        {
                            string value = matches[i].Groups[1].Value;
                            if (string.IsNullOrEmpty(value))
                                result += "\t";
                            else
                                result += value + "\t";
                        }
                        DatValue = result;
                    }

                    if (!string.IsNullOrEmpty(input1))
                        return DatValue;
                }



                if (FilterValue == Filter.DAT_Enchanted)
                {
                    if (comboBox1.SelectedIndex == 1) //446
                    {
                     Match matchBefore = Regex.Match(input1, @"\{\[([^;\]]+?)\];\{(.+?)\;(.+?)\;(.+?)\}\;\{(.+?)\;(.+?)\;(.+?)\}\;");
                    Match matchAfter = Regex.Match(input1, @"\}\;\{\[([^;\]]+?)\];\{(.+?)\;(.+?)\;(.+?)\}\;\{(.+?)\;(.+?)\;(.+?)\}\;");

                    string[] Before = new string[8];
                    string[] After = new string[8];


                        for (int i = 0; i < 8; i++)
                        {
                            Before[i] = matchBefore.Groups[i].Value.Replace("None", "");
                            After[i] = matchAfter.Groups[i].Value.Replace("None", "");
                            if (i != 1)
                            {
                                if (float.TryParse(Before[i], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float numberBefore))
                                    Before[i] = numberBefore.ToString("F8").Replace(",", ".");

                                if (float.TryParse(After[i], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float numberAfter))
                                    After[i] = numberAfter.ToString("F8").Replace(",", ".");
                            }
                        }
                        if (junk1B_dual == true)
                            DatValue = (Before[1] + "\t" + After[1] + "\t" + Before[2] + "\t"
                                + Before[3] + "\t" + Before[4] + "\t" + After[2] + "\t" + After[3] + "\t" + After[4] + "\t" + Before[5] + "\t"
                                + Before[6] + "\t" + Before[7] + "\t" + After[5] + "\t" + After[6] + "\t" + After[7] + "\t");
                        else
                            DatValue = (Before[1] + "\t" + "\t" + Before[2] + "\t" + Before[3] + "\t" + Before[4] + "\t" + Before[5] + "\t" + Before[6] + "\t" + Before[7]);
                    }
                    else
                    {
                        string pattern = @"\[([^\]]*?)\]";
                        string result = "";
                        MatchCollection matches = Regex.Matches(input1, pattern);
                        int maxCount = Math.Min(matches.Count, 2);

                        for (int i = 0; i < maxCount; i++)
                        {
                            string value = matches[i].Groups[1].Value;
                            if (string.IsNullOrEmpty(value))
                                result += "\t";
                            else
                                result += value + "\t";
                        }
                        DatValue = result;
                    }
                    if (!string.IsNullOrEmpty(input1))
                        return DatValue;
                }
                if(FilterValue == Filter.DAT_EnchantedValue)
                {
                    MatchCollection matches = Regex.Matches(input1, @"(\d+.\d+)");
                    int dualIndex = 0;


                        if (junk1B_dual == true)
                        dualIndex = 6;
                        else
                        dualIndex = 3;

                        int maxCount = Math.Min(matches.Count, dualIndex);
                    string result = "";

                    for (int i = 0; i < maxCount; i++)
                    {
                        string value = matches[i].Groups[1].Value;
                        float valueAsDouble;
                        if (float.TryParse(matches[i].Groups[1].Value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out valueAsDouble))
                            result += valueAsDouble.ToString("F8").Replace(",", ".") + "\t";

                    }
                    DatValue = result;
                    if (!string.IsNullOrEmpty(input1))
                        return DatValue;
                }


                if (FilterValue == Filter.DAT_icon || FilterValue == Filter.DAT_Sound || FilterValue == Filter.DAT_Wp_Mesh_Tex || FilterValue == Filter.DAT_Texture_Name_Npc)
                    matchesBefore = Regex.Matches(input1.Substring(0, input1.IndexOf("}")), pattern1);
                else if (FilterValue == Filter.DAT_property_list)
                {
                    string pattern = @"(\d+)";
                    matchesBefore = Regex.Matches(input1, pattern);
                }
                else if (FilterValue == Filter.DAT_DeccoEffect)
                    matchesBefore = Regex.Matches(input1.Substring(0, input1.IndexOf("}")), pattern1);
                else
                {
                    string pattern3 = @"\[([^\]]*?)\]";
                    if (!string.IsNullOrEmpty(input1) && !input1.Contains(";{"))
                        matchesBefore = Regex.Matches(input1.Substring(0, input1.IndexOf(";")), pattern3);
                    else
                    matchesBefore = Regex.Matches(input1.Substring(0, input1.IndexOf(";{")), pattern1);

                }

                var filteredBefore = matchesBefore.Cast<Match>().Select(m => m.Groups[1].Value).Where(s => s != "None");
                int countBefore = filteredBefore.Count();
                MatchCollection matchesAfter = Regex.Matches(input1.Substring(input1.IndexOf(";{") + 2), pattern1);
                var filteredAfter = matchesAfter.Cast<Match>().Select(m => m.Groups[1].Value).Where(s => s != "None");
                int countAfter = filteredAfter.Count();


                if (FilterValue == Filter.DAT_DeccoEffect)
                {
                    Match match = Regex.Match(input1, @"\{\{(\[[^\]]+\]);(\d+\.\d+)\}");
                    int bRbEffectOn = 0;

                    if (match.Groups[1].Value.Length > 0)
                        bRbEffectOn = 1;
                    string rb_effect_fl = match.Groups[2].Value;

                    if (float.TryParse(rb_effect_fl, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float numberBefore))
                        rb_effect_fl = numberBefore.ToString("F8").Replace(",", ".");

                    DatValue = bRbEffectOn + "\t" + match.Groups[1].Value.Replace("[", "").Replace("]", "") + "\t" + rb_effect_fl;
                }

                if (FilterValue == Filter.DAT_property_list)
                {
                    filteredBefore = matchesBefore.Cast<Match>().Select(m => m.Groups[1].Value).Where(s => s != "None");
                    countBefore = filteredBefore.Count();
                    DatValue = countBefore +"\t"+ wordsBefore;
                    for (int i = 42; i >= countBefore; i--)
                        DatValue += "\t";
                }

                if (FilterValue == Filter.DAT_Race_Add && countBefore != 0 && countAfter != 0)
                {
                    if (countBefore != 0 && countAfter != 0)
                    {
                        wordsBefore = string.Join("\t", matchesBefore.Cast<Match>()).Replace("[None]", "").Replace("[", "").Replace("]", "");
                        wordsAfter = string.Join("\t", matchesAfter.Cast<Match>()).Replace("[None]", "").Replace("[", "").Replace("]", "");
                    }
                }
                else
                {
                    wordsBefore = string.Join("\t", matchesBefore.Cast<Match>().Select(m => m.Groups[1].Value).Where(s => s != "None"));
                    wordsAfter = string.Join("\t", matchesAfter.Cast<Match>().Select(m => m.Groups[1].Value).Where(s => s != "None"));
                }

                if (FilterValue == Filter.DAT_DropTex)
                {
                    DatValue = wordsBefore;
                    for (int i = 3; i >= countBefore; i--)
                        DatValue += "\t";

                    DatValue += wordsAfter;
                    for (int i = 3; i >= countAfter; i--)
                        DatValue += "\t";
                }
                if (FilterValue == Filter.DAT_icon)
                {
                    DatValue = wordsBefore;
                    for (int i = 5; i >= countBefore; i--)
                        DatValue += "\t";
                }

                if (FilterValue == Filter.DAT_property_list)
                {
                    DatValue = countBefore + "\t" + wordsBefore;
                    for (int i = 42; i >= countBefore; i--)
                        DatValue += "\t";
                }

                if (FilterValue == Filter.DAT_Texture_Name_Npc)
                {
                    DatValue = countBefore + "\t" + wordsBefore;
                    for (int i = 5; i >= countBefore; i--)
                        DatValue += "\t";
                }

                if (FilterValue == Filter.DAT_Wp_Mesh)
                {
                    if (countBefore == 0)
                        countBefore = 1;

                    DatValue = countBefore + "\t" + wordsBefore;
                   
                    for (int i = 2; i >= countBefore; i--)
                        DatValue += "\t";

                    if(countBefore > 1)
                    {
                        junk1B_dual = true;
                    }
                }
                if (FilterValue == Filter.DAT_Wp_Mesh_Tex)
                {
                    if (countBefore == 0)
                        countBefore = 1;

                    DatValue = countBefore + "\t" + wordsBefore;

                    for (int i = 3; i >= countBefore; i--)
                        DatValue += "\t";
                }
                if (FilterValue == Filter.DAT_Race)
                {
                    if (countBefore == 0)
                        countBefore = 1;

                    DatValue = countBefore + "\t" + wordsBefore;

                    for (int i = 4; i >= countBefore; i--)
                            DatValue += "\t";

                    if (countAfter == 0)
                        countAfter = 1;

                    DatValue += countAfter + "\t" + wordsAfter;
                    for (int i = 4; i >= countAfter; i--)
                            DatValue += "\t";
                }
                if (FilterValue == Filter.DAT_Race_Add)
                {
                    if(wordsAfter.Length > 5 && wordsAfter.Length > 5)
                    {
                        bNoDatRaсe_add = true;
                        string count1 = "0";
                        string count2 = "0";

                        if (wordsBefore.Length > 0) count1 = "4";
                        else count1 = "1";

                        if (wordsAfter.Length > 0) count2 = "4";
                        else count2 = "1";

                        DatValue = count1 + "\t" + wordsBefore;
                        for (int i = 4; i >= countBefore; i--)
                            DatValue += "\t";
                        DatValue += count2 + "\t" + wordsAfter;
                        for (int i = 4; i >= countAfter; i--)
                            DatValue += "\t";
                    }
                    else
                    {
                        int NumAdd = 0;

                        if (bNoDatRaсe_add)
                            NumAdd = 4;
                        else
                            NumAdd = 1;

                        if (countBefore == 0)
                            countBefore = 1;

                        if (countAfter == 0)
                            countAfter = 1;

                        DatValue = NumAdd + "\t" + wordsBefore;
                        for (int i = 4; i >= countBefore; i--)
                            DatValue += "\t";

                        DatValue += NumAdd + "\t" + wordsAfter;
                        for (int i = 4; i >= countAfter; i--)
                            DatValue += "\t";
                    }    
                }
                if (FilterValue == Filter.DAT_Sound)
                {
                    if (countBefore == 0)
                        countBefore = 1;

                    DatValue = countBefore + "\t" + wordsBefore;
                    for (int i = 4; i >= countBefore; i--)
                        DatValue += "\t";
                }
            }
            return DatValue;
        }

        public void Weapongrp()
        {
            if (textBox1.Text.Length > 0)
                textBox1.Text = "";

            bNoDatRaсe = false;
            junk1B_dual = false;

            objectId = Find(objectId, "object_id=");
            drop_type = Find(drop_type, "drop_type=");
            drop_anim_type = Find(drop_anim_type, "drop_anim_type=");
            drop_radius = Find(drop_radius, "drop_radius=");
            drop_height = Find(drop_height, "drop_height=");


            drop_texture = ParseDat(drop_texture, "drop_texture=", Filter.DAT_DropTexWeapon);
            if(comboBox1.SelectedIndex == 0)
            drop_mesh = ParseDat(drop_mesh, "drop_mesh=", Filter.DAT_DropTexWeapon);

            icon = ParseDat(icon, "icon=", Filter.DAT_icon);
            durability = Find(durability, "durability=");
            weight = Find(weight, "weight=");
            material_type = Find(material_type, "material_type=");
            material_type = ParseNameToNum(material_type, 4);
            crystallizable = Find(crystallizable, "crystallizable=");
            body_part = Find(body_part, "body_part=");
            body_part = ParseNameToNum(body_part, 5);
            handness = Find(handness, "handness=");
            handness = ParseNameToNum(handness, 6);
            wp_mesh = ParseDat(wp_mesh, "wp_mesh=", Filter.DAT_Wp_Mesh);
            texture = ParseDat(texture, "texture=", Filter.DAT_Wp_Mesh_Tex);
            item_sound = ParseDat(item_sound, "item_sound=", Filter.DAT_Sound);
            drop_sound = Find(drop_sound, "drop_sound=");
            if (drop_sound != null) drop_sound = drop_sound.Trim('[').Trim(']').Replace("None", "");
            equip_sound = Find(equip_sound, "equip_sound=");
            if (equip_sound != null) equip_sound = equip_sound.Trim('[').Trim(']').Replace("None", "");
            effect = Find(effect, "effect=");
            if (effect != null) effect = effect.Trim('[').Trim(']').Replace("None" ,"");
            random_damage = Find(random_damage, "random_damage=");
            weapon_type = Find(effect, "weapon_type=");
            weapon_type = ParseNameToNum(weapon_type, 7);
            crystal_type = Find(crystal_type, "crystal_type=");
            crystal_type = ParseNameToNum(crystal_type, 2);

            if (comboBox1.SelectedIndex == 0)
            {
                int result;
                bool isInt = int.TryParse(crystal_type, out result);

                if (isInt && result > 5)
                    crystal_type = "5";
                if(!isInt)
                    crystal_type = "0";
            }



            mp_consume = Find(mp_consume, "mp_consume=");
            soulshot_count = Find(soulshot_count, "soulshot_count=");
            spiritshot_count = Find(spiritshot_count, "spiritshot_count=");
            curvature = Find(curvature, "curvature=");
            can_equip_hero = Find(can_equip_hero, "can_equip_hero=");

            if (comboBox1.SelectedIndex == 1) //446
                Enchanted = ParseDat(Enchanted, "Enchanted=", Filter.DAT_Enchanted);
            else
            {
                EnchantedMesh = ParseDat(EnchantedMesh, "EnchantedMesh=", Filter.DAT_Enchanted);
                EnchantedMeshOffset = ParseDat(EnchantedMeshOffset, "EnchantedMeshOffset=", Filter.DAT_EnchantedValue);
                EnchantedMeshScale = ParseDat(EnchantedMeshScale, "EnchantedMeshScale=", Filter.DAT_EnchantedValue);
            }

            if (bNoDatRaсe)
                return;

            //Interlude
            textBox1.Text = "0\t"; // tag
            textBox1.Text += objectId + "\t"; // id
            textBox1.Text += drop_type + "\t"; // drop_type
            textBox1.Text += drop_anim_type + "\t"; // drop_anim_type
            textBox1.Text += drop_radius + "\t"; // drop_radius
            textBox1.Text += drop_height + "\t"; // drop_height
            textBox1.Text += "0\t"; // UNK_0//
            textBox1.Text += drop_mesh;
            textBox1.Text += drop_texture; // drop_mesh[3] drop_tex[3]        
            textBox1.Text += icon; // icon[5]
            textBox1.Text += "-1\t"; // durability
            textBox1.Text += weight + "\t"; // weight
            textBox1.Text += material_type + "\t"; // material
            textBox1.Text += crystallizable + "\t"; // crystallizable
            textBox1.Text += durability + "\t";// projectile_? ??
            textBox1.Text += body_part + "\t"; // body_part
            textBox1.Text += handness + "\t";
            textBox1.Text += wp_mesh;
            textBox1.Text += texture;
            textBox1.Text += item_sound; // item_sound_cnt	item_sound[3]
            textBox1.Text += drop_sound + "\t"; // drop_sound
            textBox1.Text += equip_sound + "\t"; //equip_sound
            textBox1.Text += effect + "\t"; //effect
            textBox1.Text += random_damage + "\t"; //effect
            textBox1.Text += "0\t";
            textBox1.Text += "0\t";
            textBox1.Text += weapon_type + "\t"; ;
            textBox1.Text += crystal_type + "\t"; //crystal_type
            textBox1.Text += "0\t";//critical
            textBox1.Text += "0\t";//hit_mod
            textBox1.Text += "0\t";//avoid_mod
            textBox1.Text += "0\t";//shield_pdef
            textBox1.Text += "0\t";//shield_rate
            textBox1.Text += "0\t";//speed
            textBox1.Text += mp_consume + "\t";//mp_consume
            textBox1.Text += soulshot_count + "\t";
            textBox1.Text += spiritshot_count + "\t";
            textBox1.Text += curvature + "\t";
            textBox1.Text += "0\t";//UNK_2
            textBox1.Text += can_equip_hero + "\t";
            textBox1.Text += "0\t";//UNK_3
            textBox1.Text += "\t";//effA
            textBox1.Text += "\t";//effB
            if (junk1B_dual == true)
                textBox1.Text += "0.00000000\t0.00000000\t0.00000000\t0.00000000\t0.00000000\t0.00000000\t1.00000000\t1.00000000\t1.00000000\t1.00000000\t";  // junk1B[5] junk1B[5]
            else
                textBox1.Text += "0.00000000\t0.00000000\t0.00000000\t1.00000000\t1.00000000\t\t\t\t\t\t";// junk1B[5] junk1B[5]

            textBox1.Text += Enchanted;
            textBox1.Text += EnchantedMesh; //p26
            if (junk1B_dual == false && comboBox1.SelectedIndex == 0)
                textBox1.Text += "\t";
            textBox1.Text += EnchantedMeshOffset;//p26
            textBox1.Text += EnchantedMeshScale;//p26

            if (junk1B_dual == false && comboBox1.SelectedIndex == 1)
                textBox1.Text += "\t\t\t\t\t\t\t";
            else if (junk1B_dual == false)
                textBox1.Text += "\t\t\t\t\t\t";

            textBox1.Text += "-1	-1	-1	-1				";
            textBox1.Text += "\n";
        }
        public void Npcgrp()
        {
            if (textBox1.Text.Length > 0)
                textBox1.Text = "";

            bNoDatRaсe = false;

            objectId = Find(objectId, "npc_id=");
            class_name = Find(class_name, "class_name=");
            if (class_name != null) class_name = class_name.Trim('[').Trim(']').Replace("None", "");
            wp_mesh_NPC = Find(wp_mesh_NPC, "mesh_name=");
            if (wp_mesh_NPC != null) wp_mesh_NPC = wp_mesh_NPC.Trim('[').Trim(']').Replace("None", "");
            texture_name = ParseDat(texture_name, "texture_name=", Filter.DAT_Texture_Name_Npc);
            property_list = ParseDat(property_list, "property_list=", Filter.DAT_property_list);
            npc_speed = Find(npc_speed, "npc_speed=");

            attack_sound1 = ParseDat(attack_sound1, "attack_sound1=", Filter.DAT_Wp_Mesh_Tex);
            defense_sound1 = ParseDat(defense_sound1, "defense_sound1=", Filter.DAT_Texture_Name_Npc);
            damage_sound = ParseDat(damage_sound, "damage_sound=", Filter.DAT_Wp_Mesh_Tex);

            deco_effect = ParseDat(deco_effect, "deco_effect=", Filter.DAT_DeccoEffect);

            attack_effect = Find(attack_effect, "attack_effect=");
            if (attack_effect != null) attack_effect = attack_effect.Trim('[').Trim(']').Replace("None", "");

            if (float.TryParse(npc_speed, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float number))
                npc_speed = number.ToString("F8");

            sound_rad = Find(sound_rad, "sound_radius=");
            sound_vol = Find(sound_vol, "sound_vol=");
            sound_rnd = Find(sound_rnd, "sound_random=");

            if (float.TryParse(sound_rad, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float numbersound_rad))
                sound_rad = numbersound_rad.ToString("F8").Replace(",", ".");
            if (float.TryParse(sound_vol, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float numbersound_vol))
                sound_vol = numbersound_vol.ToString("F8").Replace(",", ".");
            if (float.TryParse(sound_rnd, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float numbersound_rnd))
                sound_rnd = numbersound_rnd.ToString("F8").Replace(",", ".");

            if (bNoDatRaсe)
                return;
            
            textBox1.Text = objectId + "\t"; // tag
            textBox1.Text += class_name + "\t"; // class
            textBox1.Text += wp_mesh_NPC + "\t"; // mesh
            textBox1.Text += texture_name; // texture
            textBox1.Text += "0\t\t\t";
            textBox1.Text += property_list;
            textBox1.Text += npc_speed.Replace(",", ".") + "\t";
            textBox1.Text += "0\t\t";
            textBox1.Text += attack_sound1;
            textBox1.Text += defense_sound1;
            textBox1.Text += damage_sound;
            textBox1.Text += deco_effect + "\t"; //rb_effect_on rb_effect rb_effect_fl

            textBox1.Text += "1\t0\t\t\t\t\t"; //unk1_cnt	unk1_tab[4]
            textBox1.Text += attack_effect + "\t"; // effect
            textBox1.Text += "0\t"; //UNK_2

            textBox1.Text += sound_vol + "\t";
            textBox1.Text += sound_rad + "\t";         
            textBox1.Text += sound_rnd + "\t";
            textBox1.Text += "0\t0";
            textBox1.Text += "\n";
        }
        public void Armorgrp()
        {

            if (textBox1.Text.Length > 0)
                textBox1.Text = "";

            bNoDatRaсe = false;
            bNoDatRaсe_add = false;

            objectId = Find(objectId, "object_id=");
            drop_type = Find(drop_type, "drop_type=");
            drop_anim_type = Find(drop_anim_type, "drop_anim_type=");
            drop_radius = Find(drop_radius, "drop_radius=");
            drop_height = Find(drop_height, "drop_height=");

            if (comboBox1.SelectedIndex == 0)
            {
                drop_texture = ParseDat(drop_texture, "drop_texture=", Filter.DAT_DropTexWeapon);
                drop_mesh = ParseDat(drop_mesh, "drop_mesh=", Filter.DAT_DropTexWeapon);
            }
            else
            drop_texture = ParseDat(drop_texture, "drop_texture=", Filter.DAT_DropTex);
            icon = ParseDat(icon, "icon=", Filter.DAT_icon);
            weight = Find(weight, "weight=");
            material_type = Find(material_type, "material_type=");
            material_type = ParseNameToNum(material_type, 4);
            crystallizable = Find(crystallizable, "crystallizable=");
            body_part = Find(body_part, "body_part=");
            body_part = ParseNameToNum(body_part, 1);
            m_HumnFigh = ParseDat(m_HumnFigh, "m_HumnFigh=", Filter.DAT_Race);
            f_HumnFigh = ParseDat(f_HumnFigh, "f_HumnFigh=", Filter.DAT_Race);
            m_DarkElf = ParseDat(m_DarkElf, "m_DarkElf=", Filter.DAT_Race);
            f_DarkElf = ParseDat(f_DarkElf, "f_DarkElf=", Filter.DAT_Race);
            m_Dorf = ParseDat(m_Dorf, "m_Dorf=", Filter.DAT_Race);
            f_Dorf = ParseDat(f_Dorf, "f_Dorf=", Filter.DAT_Race);
            m_Elf = ParseDat(m_Elf, "m_Elf=", Filter.DAT_Race);
            f_Elf = ParseDat(f_Elf, "f_Elf=", Filter.DAT_Race);
            m_HumnMyst = ParseDat(m_HumnMyst, "m_HumnMyst=", Filter.DAT_Race);
            f_HumnMyst = ParseDat(f_HumnMyst, "f_HumnMyst=", Filter.DAT_Race);
            m_OrcFigh = ParseDat(m_OrcFigh, "m_OrcFigh=", Filter.DAT_Race);
            f_OrcFigh = ParseDat(f_OrcFigh, "f_OrcFigh=", Filter.DAT_Race);
            m_OrcMage = ParseDat(m_OrcMage, "m_OrcMage=", Filter.DAT_Race);
            f_OrcMage = ParseDat(f_OrcMage, "f_OrcMage=", Filter.DAT_Race);
            m_HumnFigh_add = ParseDat(m_HumnFigh_add, "m_HumnFigh_add=", Filter.DAT_Race);
            f_HumnFigh_add = ParseDat(f_HumnFigh_add, "f_HumnFigh_add=", Filter.DAT_Race_Add);
            m_DarkElf_add = ParseDat(m_DarkElf_add, "m_DarkElf_add=", Filter.DAT_Race_Add);
            f_DarkElf_add = ParseDat(f_DarkElf_add, "f_DarkElf_add=", Filter.DAT_Race_Add);
            m_Dorf_add = ParseDat(m_Dorf_add, "m_Dorf_add=", Filter.DAT_Race_Add);
            f_Dorf_add = ParseDat(f_Dorf_add, "f_Dorf_add=", Filter.DAT_Race_Add);
            m_Elf_add = ParseDat(m_Elf_add, "m_Elf_add=", Filter.DAT_Race_Add);
            f_Elf_add = ParseDat(f_Elf_add, "f_Elf_add=", Filter.DAT_Race_Add);
            m_HumnMyst_add = ParseDat(m_HumnMyst_add, "m_HumnMyst_add=", Filter.DAT_Race_Add);
            f_HumnMyst_add = ParseDat(f_HumnMyst_add, "f_HumnMyst_add=", Filter.DAT_Race_Add);
            m_OrcFigh_add = ParseDat(m_OrcFigh_add, "m_OrcFigh_add=", Filter.DAT_Race_Add);
            f_OrcFigh_add = ParseDat(f_OrcFigh_add, "f_OrcFigh_add=", Filter.DAT_Race_Add);
            m_OrcMage_add = ParseDat(m_OrcMage_add, "m_OrcMage_add=", Filter.DAT_Race_Add);
            f_OrcMage_add = ParseDat(f_OrcMage_add, "f_OrcMage_add=", Filter.DAT_Race_Add);
            item_sound = ParseDat(item_sound, "item_sound=", Filter.DAT_Sound);
            drop_sound = Find(drop_sound, "drop_sound=");
            if (drop_sound != null) drop_sound = drop_sound.Trim('[').Trim(']').Replace("None", "");
            equip_sound = Find(equip_sound, "equip_sound=");
            if (equip_sound != null) equip_sound = equip_sound.Trim('[').Trim(']').Replace("None", "");
            armor_type = Find(armor_type, "armor_type=");
            armor_type = ParseNameToNum(armor_type, 3);
            crystal_type = Find(crystal_type, "crystal_type=");           
            crystal_type = ParseNameToNum(crystal_type, 2);

            if (comboBox1.SelectedIndex == 1)
                mp_bonus = Find(mp_bonus, "mp_bonus=");

            if (bNoDatRaсe)
                return;

            //Interlude
            textBox1.Text = "1\t"; // tag
            textBox1.Text += objectId + "\t"; // id
            textBox1.Text += drop_type + "\t"; // drop_type
            textBox1.Text += drop_anim_type + "\t"; // drop_anim_type
            textBox1.Text += drop_radius + "\t"; // drop_radius
            textBox1.Text += drop_height + "\t"; // drop_height
            textBox1.Text += "0\t"; // UNK_0//
            textBox1.Text += drop_mesh;
            textBox1.Text += drop_texture; // drop_mesh[3] drop_tex[3]
            
            textBox1.Text += icon; // icon[5]
            textBox1.Text += "4294967295\t"; // durability
            textBox1.Text += weight + "\t"; // weight
            textBox1.Text += material_type + "\t"; // material
            textBox1.Text += crystallizable + "\t"; // crystallizable
            if(bNoDatRaсe_add)
            textBox1.Text += "0\t"; // UNK_1
            else
            textBox1.Text += "31243208\t"; // UNK_1
            textBox1.Text += body_part + "\t"; // body_part
            textBox1.Text += m_HumnFigh + m_HumnFigh_add; 
            textBox1.Text += f_HumnFigh + f_HumnFigh_add;
            textBox1.Text += m_DarkElf + m_DarkElf_add;
            textBox1.Text += f_DarkElf + f_DarkElf_add;
            textBox1.Text += m_Dorf + m_Dorf_add;
            textBox1.Text += f_Dorf + f_Dorf_add;
            textBox1.Text += m_Elf + m_Elf_add;
            textBox1.Text += f_Elf + f_Elf_add;
            textBox1.Text += m_HumnMyst + m_HumnMyst_add;
            textBox1.Text += f_HumnMyst + f_HumnMyst_add;
            textBox1.Text += m_OrcFigh + m_OrcFigh_add;
            textBox1.Text += f_OrcFigh + f_OrcFigh_add;
            textBox1.Text += m_OrcMage + m_OrcMage_add;
            textBox1.Text += f_OrcMage + f_OrcMage_add;
            textBox1.Text += "0		0		0		0		1		1		LineageEffect.p_u002_a	";
            textBox1.Text += item_sound; // item_sound_cnt	item_sound[3]
            textBox1.Text += drop_sound + "\t"; // drop_sound
            textBox1.Text += equip_sound + "\t"; //equip_sound
            textBox1.Text += "1	0	"; //UNK_2	UNK_3
            textBox1.Text += armor_type + "\t"; //armor_type
            textBox1.Text += crystal_type + "\t"; //crystal_type
            textBox1.Text += "0\t"; //avoid_mod
            textBox1.Text += "0\t"; //pdef
            textBox1.Text += "0\t"; //mdef
            textBox1.Text += mp_bonus; //mp_bonus
            textBox1.Text += "\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox0.SelectAll();
            textBox0.Copy();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
            textBox1.Copy();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox0.SelectAll();
            textBox0.Paste();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
            textBox1.Paste();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            textBox0.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        private void Parse_Click(object sender, EventArgs e)
        {
            ResetValues();
            Armorgrp();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ResetValues();
            Weapongrp();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ResetValues();
            Npcgrp();
        }
    }     
}
