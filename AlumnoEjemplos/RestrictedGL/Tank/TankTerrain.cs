﻿using System;
using AlumnoEjemplos.RestrictedGL.GuiWrappers;
using AlumnoEjemplos.RestrictedGL.Interfaces;
using Microsoft.DirectX;
using TgcViewer;
using TgcViewer.Utils.TgcSceneLoader;
using TgcViewer.Utils.TgcGeometry;

namespace AlumnoEjemplos.RestrictedGL.Tank {

    class TankTerrain : IRenderObject, ITerrainCollision
    {
        
        private TgcBox surface;

        const int SURFACE_SIZE = 3000;

        public void init(string alumnoMediaFolder){
            var d3DDevice = GuiController.Instance.D3dDevice;
            var surfaceTexture = TgcTexture.createTexture(d3DDevice, Path.TankTerrainSurface);            
            this.surface = TgcBox.fromSize(new Vector3(0, 0, 0), new Vector3(SURFACE_SIZE, 0, SURFACE_SIZE), surfaceTexture);
        }

        public bool isOutOfBounds(TgcBoundingBox boundingBox) {
            var result = TgcCollisionUtils.classifyBoxBox(boundingBox, this.surface.BoundingBox);
            return result != TgcCollisionUtils.BoxBoxResult.Atravesando;
        }

        public bool isCollidingWith(TgcBoundingBox boundingBox) {
            return false;
        }

        public void render() {
            var showBoundingBox = Modifiers.get<bool>("showBoundingBox");
            
            surface.render();
            if (showBoundingBox)
                surface.BoundingBox.render();
        }
    
        public void dispose() {
            surface.dispose();
        }

        public bool AlphaBlendEnable { get; set; }

        public void deform(float x, float z, float radius, int power) {
        }

        public float ScaleY { get; private set; }

        public float getYValueFor(float x, float z) {
            return 0;
        }
        public bool isOutOfBounds(ITransformObject tankOrMissile){
          //  var result = TgcCollisionUtils.classifyBoxBox(tankOrMissile., this.surface.BoundingBox);
          //  return result != TgcCollisionUtils.BoxBoxResult.Atravesando;
            return false;
        }
    }   
}
