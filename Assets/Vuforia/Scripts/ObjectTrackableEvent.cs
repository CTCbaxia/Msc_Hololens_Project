using UnityEngine;

namespace Vuforia
{
	    /// Summary
	    /// A custom handler that implements the ITrackableEventHandler interface.

	    public class ObjectTrackableEvent : MonoBehaviour,
	    ITrackableEventHandler
	    {
		        public GameObject TagOverlayControl;
		        private TrackableBehaviour mTrackableBehaviour;
		        private GameObject TargetSphereLocation = null;

		        void Start()
		        {
			            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			            if (mTrackableBehaviour)
				            {
				                mTrackableBehaviour.RegisterTrackableEventHandler(this);
				            }
			        }

		        /// Summary
		        /// Implementation of the ITrackableEventHandler function called when the
		        /// tracking state changes.

		        public void OnTrackableStateChanged(
			            TrackableBehaviour.Status previousStatus,
			            TrackableBehaviour.Status newStatus)
		        {
			            if (newStatus == TrackableBehaviour.Status.DETECTED ||
				                newStatus == TrackableBehaviour.Status.TRACKED ||
				                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
				            {
				                OnTrackingFound();
				            }
			            else
				            {
				                OnTrackingLost();
				            }
			        }

		        private void OnTrackingFound()
		        {
			            if (TargetSphereLocation != null)
				                return;

			            TargetSphereLocation = (GameObject)Instantiate(this.TagOverlayControl);
			            TargetSphereLocation.SetActive(true);

			            TargetSphereLocation.transform.position = transform.position;
			            TargetSphereLocation.transform.rotation = transform.rotation;
			            print(transform.position);

			            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
			        }

		        private void OnTrackingLost()
		        {
			        }
		    }
} 
