using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class NpcController : BaseController
    {
        private List<Npc> _npcList { get; set; }

        public override void On()
        {
            base.On();
            _npcList = new List<Npc>();
            Npc[] tmp = GameObject.FindObjectsOfType<Npc>();
            foreach (Npc npc in tmp)
                _npcList.Add(npc);
        }

        public void AddNpc(Npc npc)
        {
            _npcList.Add(npc);
        }

        public override void Update()
        {
            if (!IsActive)
                return;

            foreach(Npc npc in _npcList)
            {
                npc.Move();
            }
        }
    }
}
