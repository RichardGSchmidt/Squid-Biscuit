using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Reds.PhotonTutorial
{


    public class Launcher : MonoBehaviour
    {
        #region Public Variables

        #endregion

        #region Private Variables

        /// <summary>
        /// This is the client's version number.  Users are seperated from each other by gameversion.
        /// </summary>
        string _gameVersion = "1";

        #endregion

        #region MonoBehaviour Callbacks

        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
        /// </summary>
        private void Awake()
        {
            //**Criticial
            //We Don't join a lobby, there is no need to join a lobby to get the room list.
            PhotonNetwork.autoJoinLobby = false;

            //**Critical
            // This ensures that we can use PhotonNetwork.LoadLevel() on the master client and all clients in the
            // same room sync their level automatically.
            PhotonNetwork.automaticallySyncScene = true;

            
        }



        /// <summary>
        /// Mono Method called on GameObject b Unity during initiallization phase.
        /// </summary>
        void Start()
        {
            Connect();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Starts the connection process.
        /// -If already connected, we attempt joining a random room
        /// -If not yet connected, Connect this application instance to Photon Cloud Network
        /// </summary>
        /// 

        public void Connect()
        {
            //check if connected or not, join if we are, otherwise initiate connection to server
            if (PhotonNetwork.connected)
            {
                //attempts to join random room
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.ConnectUsingSettings(_gameVersion);
            }

        }

        #endregion

        // Update is called once per frame
        void Update()
        {

        }
    }

}