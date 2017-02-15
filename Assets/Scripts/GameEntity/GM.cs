using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : Singleton {


	private	List<Entity>	mEntities;	

	private	static	GM	sGM;

	void Awake () {
		if (CreateSingleton (ref sGM)) {
			sGM.mEntities = new List<Entity>();
		}
	}

	public	static	Entity	GetPlayer(int vIndex) {
		if(sGM!=null && vIndex<sGM.mEntities.Count) {
			return	sGM.mEntities[vIndex];
		}
		return	null;
	}

	public	static	void	AddPlayer(Entity vEntity) {
		if(sGM!=null) {
			sGM.mEntities.Add (vEntity);
			GameHelper.DebugMsg ("Added " + vEntity.GetType ().Name);
		}
	}

	public	static	void	RemovePlayer(Entity vEntity) {
		if(sGM!=null) {
			sGM.mEntities.Remove (vEntity);
			GameHelper.DebugMsg ("Removed " + vEntity.GetType ().Name);
		}
	}
}
