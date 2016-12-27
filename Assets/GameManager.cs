using UnityEngine;
using System.Collections;

public enum GameMode {
	Menu,
	Play,
	End
}
public delegate void GameModeWillChange(GameMode newMode);
public delegate void GameModeDidChange(GameMode newMode);

public class GameManager : MonoBehaviour {

	public static event GameModeWillChange OnGameModeWillChange;
	public static event GameModeDidChange OnGameModeDidChange;

	private static GameMode _mode = GameMode.Menu;

	public static GameMode mode {
		get { return _mode; }
		set {
			// will it change?
			if (_mode == value) { return; }

			if (OnGameModeWillChange != null) { OnGameModeWillChange(value); }
			_mode = value;
			if (OnGameModeDidChange != null) { OnGameModeDidChange(value); }
		}
	}
}
