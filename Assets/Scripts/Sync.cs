using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sync : Photon.MonoBehaviour {

    public Vector3 RealPosition = Vector3.zero;
    public Quaternion RealRotation = Quaternion.identity;

    public Vector3 RealPosition1 = Vector3.zero;
    public Quaternion RealRotation1 = Quaternion.identity;
    public Vector3 RealVelocity1 = Vector3.zero;

    public Vector3 RealVelocity2 = Vector3.zero;

    public Rigidbody rg;
	
	// Update is called once per frame

    void FixedUpdate()
    {
        if (!photonView)
        {
            rg.position = Vector3.Lerp(rg.position, RealPosition1, 0.004f);
            rg.rotation = Quaternion.Lerp(rg.rotation, RealRotation1, 0.004f);
            rg.velocity = Vector3.Lerp(rg.velocity, RealVelocity1, 0.004f);
            rg.angularVelocity = Vector3.Lerp(rg.angularVelocity, RealVelocity2, 0.004f);
        }
    }
	void Update () {

        if (!photonView){
            transform.position = Vector3.Lerp(transform.position, RealPosition, 0.004f);
            transform.rotation = Quaternion.Lerp(transform.rotation, RealRotation, 0.004f);
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);

            stream.SendNext(rg.position);
            stream.SendNext(rg.rotation);
            stream.SendNext(rg.velocity);
            stream.SendNext(rg.angularVelocity);
        }

        else
        {
            RealPosition = (Vector3)stream.ReceiveNext();
            RealRotation = (Quaternion)stream.ReceiveNext();

            RealPosition1 = (Vector3)stream.ReceiveNext();
            RealRotation1 = (Quaternion)stream.ReceiveNext();
            RealVelocity1 = (Vector3)stream.ReceiveNext();
            RealVelocity2 = (Vector3)stream.ReceiveNext();


        }
    }
}
