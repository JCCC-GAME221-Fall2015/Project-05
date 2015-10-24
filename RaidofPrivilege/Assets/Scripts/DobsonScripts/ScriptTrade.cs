using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptTrade : MonoBehaviour {

    ScriptPlayer trader;
    ScriptPlayer tradie;

    int offerWool;
    int offerLumber;
    int offerGrain;
    int offerBrick;

    int wantWool;
    int wantLumber;
    int wantGrain;
    int wantBrick;
    
    public ScriptTrade(int OfferWool, int OfferLumber, int OfferGrain, int OfferBrick,
                    int WantWool, int WantLumber, int WantGrain, int WantBrick)
    {
        offerWool = OfferWool;
        offerLumber = OfferLumber;
        offerGrain = OfferGrain;
        offerBrick = OfferBrick;
        wantWool = WantWool;
        wantLumber = WantLumber;
        wantGrain = WantGrain;
        wantBrick = WantBrick;
    }

    void AcceptTrade()
    {
        tradie.ChangeBrick(-wantBrick);
        tradie.ChangeBrick(offerBrick);
        tradie.ChangeGrain(-wantGrain);
        tradie.ChangeGrain(offerGrain);
        tradie.ChangeWood(-wantLumber);
        tradie.ChangeWood(offerLumber);
        tradie.ChangeWool(-wantWool);
        tradie.ChangeWool(offerWool);
        //tradie.outboundTrade.Enqueue();
    }

}
