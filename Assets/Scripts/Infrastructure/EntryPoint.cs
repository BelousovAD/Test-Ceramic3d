using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Matrices;
using Offsets;
using InputOutput;
using View;

namespace Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField][Min(0f)] private float _epsilon = 0.0001f;
        
        [SerializeField] private string _modelSourceFileName;
        [SerializeField] private string _spaceSourceFileName;
        [SerializeField] private string _outputFileName;
	
        [SerializeField] private Spawner _modelSpawner;
        [SerializeField] private Spawner _spaceSpawner;
	
        [SerializeField] private SelectionView _selectionView;
        [SerializeField] private OffsetApplier _offsetApplier;

        private MatrixCollection _modelCollection;
        private MatrixCollection _spaceCollection;
        private OffsetCollection _offsetCollection;

        private void Awake()
        {
            _modelCollection = new MatrixCollection(_modelSourceFileName);
            _spaceCollection = new MatrixCollection(_spaceSourceFileName);
            _offsetCollection = new OffsetCollection();

            _selectionView.Initialize(_offsetCollection);
            _offsetApplier.Initialize(_offsetCollection);

            _modelSpawner.Initialize(_modelCollection);
            _spaceSpawner.Initialize(_spaceCollection);

            _modelSpawner.Spawn();
            _spaceSpawner.Spawn();

            List<Matrix4x4> offsets =
                OffsetFinder.Find(_modelCollection.Matrices, _spaceCollection.Matrices, _epsilon).ToList();
            Writer.WriteMatrices(_outputFileName, offsets);
            _offsetCollection.Initialize(offsets);
        }
    }
}